using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    [Header("Prefabs")]
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public GameObject bulletParticles;
    public GameObject gunIcon;
    public GameObject collectBulletsPrefab; // Prefab for CollectBullets

    [Header("Sounds")]
    public AudioSource pistolSound;
    public AudioSource emptySound;

    [Header("UI")]
    public Text showBullets;

    public Animator anim;

    private int totalBullets = 30;

    private void Start()
    {
        showBullets.text = totalBullets.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CollectBullets"))
        {
            // When the player triggers the CollectBullets object
            int randomBulletAmount = Random.Range(1, 11); // Get a random number between 1 and 10
            totalBullets += randomBulletAmount;
            showBullets.text = totalBullets.ToString();
            Destroy(other.gameObject); // Destroy the CollectBullets object
        }
    }

    public void Shoot()
    {
        if (totalBullets > 0)
        {
            anim.SetTrigger("isShooting");
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            pistolSound.Play();
            gunIcon.SetActive(true);
            GameObject bulletP = Instantiate(bulletParticles, shootingPoint.position, transform.rotation);
            Destroy(bullet, 2f);
            Destroy(bulletP, 1f);

            totalBullets--;
            showBullets.text = totalBullets.ToString();
        }
        else
        {
            // Play empty sound
            if (emptySound != null)
            {
                emptySound.Play();
            }
        }
    }
}
