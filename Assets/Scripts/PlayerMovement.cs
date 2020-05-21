using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;

    Vector2 movement;

    void Start() 
    {
        rb = this.GetComponentInChildren<Rigidbody2D>();
        animator = this.GetComponentInChildren<Animator>();
    }
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("horizontal", movement.x);
        animator.SetFloat("vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

        if (movement.x == 1 || movement.x == -1 || movement.y == 1 || movement.y == -1) 
        {
            animator.SetFloat("last_horizontal_movement", movement.x);
            animator.SetFloat("last_vertical_movement", movement.y);
        }
    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);    
    }
}
