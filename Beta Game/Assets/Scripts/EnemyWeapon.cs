using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform player;
    public GameObject enemy;
    

    public float maxTime = 3f;
    private float timer = 3f;

    public float offset;

    public float bulletForce = 20f;

    public bool alive;
    public bool shoot;
    

    // Start is called before the first frame 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy yeas = enemy.GetComponent<Enemy>();
        alive = yeas.alive;
        shoot = yeas.shoot;

        
        if (alive)
        {
            Vector3 difference = player.position - transform.position;
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        }

        if (timer >= maxTime && shoot)
        {
            Shoot();
            timer = 0f;
            Debug.Log("shoot");
        }

        timer += Time.deltaTime;
        
    }
    

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);

        Destroy(bullet, 5);

    }
}
