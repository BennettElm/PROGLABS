using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float delay = 0.5f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate = 0.5f;
    public float recoilForce = 0.1f;
    public float recoilDuration = 0.05f;
    public float bulletForce = 50f;

    private float nextFire;
    private bool isFiring;
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            StartCoroutine(Fire());
        }
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyController enemy = other.GetComponent<EnemyController>();
        if (enemy != null)
        {
            StartCoroutine(enemy.DamageEnemy(damage, delay));
        }
    }


IEnumerator Fire()
    {
        if (isFiring) yield break;

        isFiring = true;
        animator.SetTrigger("Fire");

        // Instantiating the bullet
        var bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        // Adding force to the bullet
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletForce, ForceMode.Impulse);

        // Recoil effect
        rb.AddForce(-bulletSpawn.forward * recoilForce, ForceMode.Impulse);
        yield return new WaitForSeconds(recoilDuration);
        rb.velocity = Vector3.zero;

        // Destroying the bullet after 2 seconds
        Destroy(bullet, 2.0f);
        isFiring = false;
    }
}


