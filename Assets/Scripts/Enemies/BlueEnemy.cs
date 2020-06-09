using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehaviour, IEnemy
{
    [Header("Movement")]
    private float speed = 2f;
    private bool isMoving = true;
    private bool moveRight = true;

    [Header("Attributes")]
    private int lives = 1;
    private bool isDead = false;

    [Header("Sound Effects")]
    private AudioSource audioSource;

    public AudioClip HurtAudioClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.EffectsLevel;
    }

    void Update()
    {
        if (isMoving)
        {
            if (moveRight)
            {
                transform.Translate(2 * Time.deltaTime * speed, 0, 0);
            }
            else
            {
                transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
            }
        }
    }

    public void Hurt()
    {
        --lives;
        if (lives <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        Destroy(this.gameObject, 0.2f);
    }

    public void ReproduceHurtSoundEffect() 
    {
        audioSource.clip = HurtAudioClip;
        audioSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall") || collision.collider.CompareTag("Player"))
        {
            moveRight = !moveRight;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("weapon"))
        {
            // moveRight = !moveRight;
        }
    }

    #region Properties
    public bool MoveRight 
    {
        get
        {
            return moveRight;
        }
        set
        {
            moveRight = value;
        }
    }

    public bool IsMoving
    {
        get
        {
            return isMoving;
        }
        set
        {
            isMoving = value;
        }
    }

    public bool IsDead
    {
        get
        {
            return isDead;
        }
        set
        {
            isDead = value;
        }
    }

    #endregion

}