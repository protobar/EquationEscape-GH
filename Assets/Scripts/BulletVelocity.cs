using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVelocity : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bulletSpeed = 5f;
    public GameObject bloodParticles;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * bulletSpeed;
    }

    // Called when the bullet collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                GameObject blood = Instantiate(bloodParticles, transform.position, transform.rotation);
                Destroy(blood, 1f);
                enemyHealth.TakeDamage(25); 
                Destroy(gameObject); 
            }
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
