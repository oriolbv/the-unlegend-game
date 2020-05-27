using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : ExtendedBehaviour
{
    public float Thrust;
    public float KnockTime;

    private bool triggerActive = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("enemy")) 
        {
            if(!triggerActive)
            {
                triggerActive = true;
                Rigidbody2D rbEnemy = other.GetComponent<Rigidbody2D>();
                if (rbEnemy != null)
                {
                    other.GetComponent<BlueEnemy>().IsMoving = false;
                    Vector2 forceDirection = rbEnemy.transform.position - transform.position;
                    Vector2 force = forceDirection.normalized * Thrust;

                    rbEnemy.velocity = force;
                    Wait(0.2f, () => {
                        rbEnemy.velocity = new Vector2();
                        other.GetComponent<BlueEnemy>().Hurt();
                        triggerActive = false;
                    });
                }
            }
        }
    }
}
