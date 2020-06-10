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

    private void Hurt() 
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
        if (collision.collider.CompareTag("enemy"))
        {
            Debug.Log("DOUUUUUUUUUUUUUUUUUUUUCH!!!");
            if (rb != null)
            {
                Vector2 forceDirection = rb.transform.position - transform.position;
                Vector2 force = forceDirection.normalized * Thrust;

                rb.velocity = force;

                // Reproduce sound effect
                audioSource.clip = HurtAudioClip;
                audioSource.Play();

                Wait(0.5f, () => {
                        rb.velocity = new Vector2();
                        Hurt();
                    });
            }
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
