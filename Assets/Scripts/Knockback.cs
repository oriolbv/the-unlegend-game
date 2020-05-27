using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float Thrust;
    public float KnockTime;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("enemy")) 
        {
            Rigidbody2D rbEnemy = other.GetComponent<Rigidbody2D>();
            if(rbEnemy != null) 
            {
                rbEnemy.isKinematic = false;
                Vector2 difference = rbEnemy.transform.position - transform.position;
                difference = difference.normalized * Thrust;
                rbEnemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(rbEnemy, other));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D rb, Collider2D enemy) 
    {
        if(rb != null) {
            yield return new WaitForSeconds(KnockTime);
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
            // Hurt enemy
            enemy.GetComponent<BlueEnemy>().Hurt();
        }
    }
}
