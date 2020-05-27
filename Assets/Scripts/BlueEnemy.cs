using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehaviour, IEnemy
{
    [Header("Movement")]
    private float speed = 2f;
    private bool moveRight = true;

    [Header("Attributes")]
    private int lives = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight)
        {
            // transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            // transform.Translate(-2 * Time.deltaTime * speed, 0, 0);
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

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            moveRight = !moveRight;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("weapon"))
        {
            Debug.Log("AUCH");
        }
    }


}