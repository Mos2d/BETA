using System.Collections;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] private LayerMask m_WhatIsGround;                          
    [SerializeField] private Transform m_GroundCheck;

    public GameObject losing;

    public static bool alive = true;

    const float k_GroundedRadius = .2f;

    private float speed = 7f;
    public static float moveX = 0f;

    private bool isGrounded;
    public static bool facingDirR = true;

    public Animator anim;
    public ParticleSystem blood;

    // Start is called before the first frame u
    void Start()
    {
        Time.timeScale = 1f;
        alive = true;
        //transform.rotation;
        facingDirR = true;
        isGrounded = false;
    }
    IEnumerator yay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        anim.SetBool("back", false);
    }

    
// Update is called on
void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("ctrl", true);
            moveX = 0f;
        }
        else
        {
            anim.SetBool("ctrl", false);
        }


        if (alive && !anim.GetBool("ctrl"))
        {
            Movement(); //A and D keys to move in both directions and activating the 
        }

        Jump(); //activating the jump motion with the animation up and



        if (moveX > 0 && !facingDirR)
        {
            Flip();
        }
        else if (moveX < 0 && facingDirR)
        {
            Flip();
        }
        
        
    }
    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(moveX *  speed, playerRB.velocity.y);

        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                
                isGrounded = true;
            }
        }
    }

    IEnumerator Wait(float waitTime)
    {
        Timer.moved = false;
        losing.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Lava"))
        {

            StartCoroutine(Wait(1));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            blood.Play();
            blood.transform.position = collision.transform.position;
            anim.SetBool("Dying", true);
            Destroy(collision.gameObject);
            alive = false;
            playerRB.constraints = RigidbodyConstraints2D.FreezePositionX;
            
            //anim.SetBool("Dying", true);
        }
    }
    
        
    

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        isGrounded = false;
    //    }
    //}
    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerRB.AddForce(new Vector2(0f, 30f), ForceMode2D.Impulse);
        }
        if (!isGrounded && playerRB.velocity.y > 0)
        {
            anim.SetBool("jump", true);
            anim.SetBool("down", false);
            anim.SetBool("run", false);
        }
        else if (!isGrounded && playerRB.velocity.y <= 0)
        {
            anim.SetBool("jump", false);
            anim.SetBool("down", true);
            anim.SetBool("run", false);
        }
        else
        {
            anim.SetBool("jump", false);
            anim.SetBool("down", false);
        }
    }
    private void Flip()
    {
        facingDirR = !facingDirR;

        transform.Rotate(0f, 180f, 0f);

        //Vector3 theScale = transform.localScale;
        //theScale.x *= -1;
        //transform.localScale =
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            anim.SetBool("run", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
            anim.SetBool("run", true);
        }
        else
        {
            moveX = 0f;
            anim.SetBool("run", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("slide", true);
        }
        else
        {
            anim.SetBool("slide", false);
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("back", true);
            StartCoroutine(yay(0.48f));

        } 



    }
}
