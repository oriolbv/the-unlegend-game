using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : MonoBehaviour, IEnemy
{
    [Header("Components")]
    private SpriteRenderer spriteRenderer;

    [Header("Movement")]
    private float speed = 2f;
    private bool isMoving = true;
    private bool moveRight = true;

    [Header("Attributes")]
    private int lives = 1;

    [Header("Materials")]
    private Material whiteMaterial;
    private Material defaultMaterial;

    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        //whiteMaterial = Resources.Load("WhiteMaterial", typeof(Material)) as Material;
        //defaultMaterial = spriteRenderer.material;
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
    }

    public void Hurt()
    {
        --lives;
        //spriteRenderer.material = whiteMaterial;
        if (lives <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
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