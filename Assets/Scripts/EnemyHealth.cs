using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private int health =100;
    /*public void SetHealth(int initialHealth)
    {
        health = initialHealth;
    }*/

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject); // Destroy the enemy when health reaches 0
    }
}
