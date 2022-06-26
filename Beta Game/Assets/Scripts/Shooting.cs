using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public ParticleSystem gunFlash;

    // Start is called before the first frame
    void Start()
    {
        
    }

    // Update is called once per fram
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Player.alive)
        {
            Shoot();
            
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        gunFlash.Play();
        gunFlash.transform.position = firePoint.position;

        Destroy(bullet, 1.5f);
        
    }
}
