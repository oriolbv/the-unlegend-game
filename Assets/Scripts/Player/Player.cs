using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : ExtendedBehaviour
{

    public GameObject LivesIndicator;
    private int lives = 3;
    private bool isDead = false;

    public float Thrust;
    public float KnockTime;

    [Header("Components")]
    private Rigidbody2D rb;

    [Header("Sound Effects")]
    private AudioSource audioSource;

    public AudioClip SwordAudioClip;
    public AudioClip HurtAudioClip;

    void Start() 
    {
        rb = this.GetComponentInChildren<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();
        audioSource.volume = OptionsSingleton.Instance.EffectsLevel;
    }

    public void UpdateLivesIndicator()
    {
        LivesIndicator.GetComponent<LivesIndicator>().UpdateLivesIndicator(lives);
    }

    public void Hurt() 
    {
        --lives;
        UpdateLivesIndicator();
        if (lives <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
        SceneManager.LoadScene("GameOverScene");
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("enemy") || collision.collider.CompareTag("boss"))
        {
            if (rb != null)
            {
                Vector2 forceDirection = rb.transform.position - transform.position;
                Vector2 force = forceDirection.normalized * Thrust;

                rb.velocity = force;

                

                Wait(0.5f, () => {
                        rb.velocity = new Vector2();
                        Hurt();
                    });
            }
        } 
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("boss_battle"))
        {
            GameState.Instance.IsBossBattleStarted = true;
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            GameState.Instance.IsFinished = true;
        }
        else if (other.gameObject.CompareTag("bullet"))
        {
            // Reproduce sound effect
            audioSource.clip = HurtAudioClip;
            audioSource.Play();

            Destroy(other.gameObject);

            Wait(0.5f, () => {
                rb.velocity = new Vector2();
                Hurt();
            });
        }
    }

    public void ReproduceSwordSoundEffect()
    {
        audioSource.clip = SwordAudioClip;
        audioSource.Play();
    }

    #region Properties

    public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;
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
