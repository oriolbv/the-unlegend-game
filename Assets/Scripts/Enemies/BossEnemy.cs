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

    // Start is called before the first frame update
    void Start()
    {
        shootingTimer = shootingCooldown;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("wall"))
        {
            moveRight = !moveRight;
        }
    }

    public void Hurt()
    {
        isMoving = true;
        //throw new System.NotImplementedException();
    }

    public void Die()
    {
        //throw new System.NotImplementedException();
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
