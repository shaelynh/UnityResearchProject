﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public Rigidbody2D theRB;
    public float jumpForce;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR;


    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
 
            // less slippy // theRB.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), theRB.velocity.y);
            //or
            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatIsGround);

            if (isGrounded)
            {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump"))
            {

                if (isGrounded)
                {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                }
                else
                {
                    if (canDoubleJump)
                    {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
                        canDoubleJump = false;
                    }
                }
            }
            
            if (theRB.velocity.x < 0)
            {
            theSR.flipX = false;

            }
            else if (theRB.velocity.x > 0)
            //if not moving 
            {
            theSR.flipX = true;
            }

        //animations
        anim.SetFloat("moveSpeed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
    }

}

