using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public ParticleSystem gunExplode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            
            Destroy(collision.gameObject);
            gunExplode.Play();
            gunExplode.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}
