using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : ExtendedBehaviour
{

    public GameObject HealthIndicator;
    private int lives = 3;
    private bool isDead = false;

    public float Thrust;
    public float KnockTime;

    [Header("Components")]
    private Rigidbody2D rb;

    void Start() 
    {
        rb = this.GetComponentInChildren<Rigidbody2D>();
    }

    public void UpdateHealthIndicator()
    {

    }

    private void Hurt() 
    {
        Debug.Log("Hurt!");
        --lives;
        if (lives <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        isDead = true;
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
                    Wait(0.5f, () => {
                        rb.velocity = new Vector2();
                        Hurt();
                    });
            }
        }
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
