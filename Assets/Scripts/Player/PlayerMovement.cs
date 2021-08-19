using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    public float speed;
    public int jumpForce;
    public bool isGrounded;
    public LayerMask isGroundLayer;
    public Transform groundCheck;
    public float groundCheckRadius;
    public bool isShooting;

    public int score = 0;
    public int lives = 1;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        if (speed<=0)
        { 
            speed = 2.0f;
        }

        if (jumpForce <=0)
        {
            jumpForce = 250;
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.05f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);
        }

        Vector2 moveDirection = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = moveDirection;

        anim.SetFloat("speed", Mathf.Abs (horizontalInput));
        anim.SetBool("isGrounded", isGrounded);

            //going left: horizontalInput = -1, sr.flipx=true;
            //going right: horizontalInput = 1, sr.flipx=false;

        if(sr.flipX && horizontalInput > 0 || !sr.flipX && horizontalInput < 0)
            sr.flipX = !sr.flipX;


        if (Input.GetButtonDown("Jump") && Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("isFiring", true);
        }

    }
}