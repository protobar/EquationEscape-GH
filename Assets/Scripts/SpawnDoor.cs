using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoor : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float doorLifeTime = 5f;
    public float spawnSpeed = 3f;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        enemyRb.velocity = new Vector2(-spawnSpeed, 0);
        Destroy(enemy, doorLifeTime);
    }
}
