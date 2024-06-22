using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment22 : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool grounded;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(horizontalinput * speed, rb2d.velocity.y);

        //flipping the character sprite according to our A and D movement
        if(horizontalinput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalinput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
        }

        //Animator parameter setting
        anim.SetBool("run", horizontalinput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
    }
}
