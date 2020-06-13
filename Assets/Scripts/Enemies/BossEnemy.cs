using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour, IEnemy
{
     
    [Header("Movement")]
    private float speed = 2f;
    private bool isMoving = true;
    private bool moveRight = true;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public float bulletSpeed;
    public float shootingCooldown;
    private float shootingTimer;

    [Header("Sound Effects")]
    private AudioSource audioSource;
    public AudioClip HurtAudioClip;

    [Header("Attributes")]
    private int lives = 3;
    private bool isDead = false;

    [Header("Particle Systems")]
    public ParticleSystem DeadExplosionParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        shootingTimer = shootingCooldown;

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.EffectsLevel;
    }

    // Update is called once per frame
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

        if (!isDead)
        {
            shootingTimer -= Time.deltaTime;
            if (shootingTimer <= 0)
            {
                shootingTimer = shootingCooldown;
                GameObject bulletInstance = Instantiate(bulletPrefab);
                bulletInstance.transform.SetParent(transform.parent);
                bulletInstance.transform.position = transform.position;
                bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bulletSpeed);
                Destroy(bulletInstance, 5f);
            }
        }
    }

    public void ReproduceHurtSoundEffect()
    {
        audioSource.clip = HurtAudioClip;
        audioSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            moveRight = !moveRight;
        }
    }

    public void Hurt()
    {
        Debug.Log("Hurt!");
        --lives;
        isMoving = true;
        if (lives <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Die!");
        isDead = true;
        DeadExplosionParticleSystem.Play();
        // Set sprite transparency in order to disappear but not destroy the object yet.
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Destroy(this.gameObject, 2f);
    }

    #region Properties
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

    #endregion
}
