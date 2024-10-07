using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpingpower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D rb2d;
    private Animator anim;
    private BoxCollider2D boxcollider;
    private float walljumpcooldown;
    private float horizontalinput;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate() 
    {
        horizontalinput = Input.GetAxis("Horizontal");

        //flipping the character sprite according to our A and D movement
        if(horizontalinput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalinput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Animator parameter setting
        anim.SetBool("run", horizontalinput != 0);
        anim.SetBool("grounded", isGrounded());
        if (rb2d.velocity.y < -0.1f && isGrounded())
        {
            anim.SetBool("isjumping", false);
        }

        //wall jump kaya mario
        if (walljumpcooldown < 0.2f)
        {
            rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y);

            if (onwall() && !isGrounded())
            {
                rb2d.gravityScale = 0;
                rb2d.velocity = Vector2.zero;
                 anim.SetBool("wallstay", true);
            }
            else
            {
                rb2d.gravityScale = 6f;
                 anim.SetBool("wallstay", false);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }
        }
        else
        {
            walljumpcooldown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpingpower);
            anim.SetTrigger("jump");
            anim.SetBool("isjumping", true);
        }
        else if (onwall() && !isGrounded())
        {
            anim.SetBool("wallstay", true);
            if (horizontalinput == 0)
            {
                rb2d.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 80f, 10);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
            {
                rb2d.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 0.001f, 6);
            }
            walljumpcooldown = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D ded) 
   {
        if(ded.collider.CompareTag("void"))
        {
            SceneManager.LoadScene("Retrying");
        }
   }

    private bool isGrounded()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycasthit.collider != null;
    }

    private bool onwall()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycasthit.collider != null;
    }
}

