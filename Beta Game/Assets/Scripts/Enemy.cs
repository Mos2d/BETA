using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject head;

    public Rigidbody2D enemyRB;

    public Animator animE;
    public Animator anim;

    public ParticleSystem blood;

    public Transform player;

    public bool shoot = false;
    public bool alive = true;

    public static bool facingDirR = false;

    private float distancePlayer = 15f;
    // Start is called before the first frame update
    void Start()
    {
        
        facingDirR = false;
        alive = true;
    }

    // Update is called once per 
    void Update()
    {
        
        
        if (Vector3.Distance(transform.position, player.position) < distancePlayer && alive)
        {
            shoot = true;
        }else
        {
            shoot = false;
        }
        

        enemyRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            //Instantiate(head, transform.position, Quaternion.identity);
            blood.Play();
            blood.transform.position = collision.transform.position;
            Destroy(collision.gameObject);
            animE.SetBool("DyingE", true);
            //Destroy(gameObject, 2);
            alive = false;

            enemyRB.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (anim.GetBool("slide") == true)
            {
                blood.Play();
                blood.transform.position = transform.position;
                animE.SetBool("back", true);
                
                StartCoroutine(yay(0.42f));
                //animE.SetBool("back", false);
                //animE.SetBool("Dying", true);
                alive = false;
            }
            
            
        }
        
    }
    IEnumerator yay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        animE.SetBool("back", false);
        animE.SetBool("DyingE", true);
    }

    
}
