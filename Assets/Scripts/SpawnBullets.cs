using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnInterval = 2f;
    public float bulletLifetime = 5f;
    public float bulletMoveSpeed = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnBullet", 0f, spawnInterval);
    }

    private void SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        bulletRb.velocity = new Vector2(-bulletMoveSpeed, 0);

        Destroy(bullet, bulletLifetime);
    }
}
