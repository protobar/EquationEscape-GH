using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float enemyLifetime = 5f;
    public float enemySpeed = 3f;
    public int enemyHealth = 100; // Add health variable



    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        enemyRb.velocity = new Vector2(-enemySpeed, 0);

        EnemyHealth enemyHealthScript = enemy.GetComponent<EnemyHealth>();

        Destroy(enemy, enemyLifetime);
    }
}
