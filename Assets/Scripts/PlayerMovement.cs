using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [Header("Components")]
    private Rigidbody2D rb;
    private Animator animator;

    [Header("Movement")]
    Vector2 movement;
    public float moveSpeed = 5f;

    [Header("Hit zones")]
    private GameObject frontHitZone;
    private GameObject rearHitZone;
    private GameObject leftHitZone;
    private GameObject rightHitZone;


    void Start() 
    {
        rb = this.GetComponentInChildren<Rigidbody2D>();
        animator = this.GetComponentInChildren<Animator>();

        // Obtaining the different hit zones
        frontHitZone = GameObject.Find("FrontHitZone");
        rearHitZone = GameObject.Find("RearHitZone");
        leftHitZone = GameObject.Find("LeftHitZone");
        rightHitZone = GameObject.Find("RightHitZone");

        // Set active flag to false for all hit zones
        frontHitZone.SetActive(false);
        rearHitZone.SetActive(false);
        leftHitZone.SetActive(false);
        rightHitZone.SetActive(false);
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

        if (Input.GetButtonDown("Jump"))
        {
            StartCoroutine(Attack());
        }
        
    }

    private IEnumerator Attack()
    {
        frontHitZone.SetActive(true);
        animator.SetBool("is_attacking", true);
        yield return null;
        animator.SetBool("is_attacking", false);
        yield return new WaitForSeconds(.50f);
        frontHitZone.SetActive(false);

    }

    void FixedUpdate() 
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);    
    }
}
