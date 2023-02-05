using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public int jumpsAmount;
    public int healthPoints = 3;
    int jumpsLeft;

    //public Transform GroundCheck;
    //public LayerMask GroundLayer;

    //bool isGrounded;

    float moveInput;
    Rigidbody2D rb2d;
    float scaleX;
    CircleCollider2D groundCollider;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        //groundCollider = GroundCheck.GetComponent<CircleCollider2D>();
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        //CheckIfGrounded();
        //ResetJumps();
        Move();
        //Flip();
    }

    public void Move()
    {
        rb2d.velocity = new Vector2(moveInput * moveSpeed, rb2d.velocity.y);
    }

    //public void Flip()
    //{
    //    if (moveInput > 0)
    //    {
    //        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
    //    }
    //    if (moveInput < 0)
    //    {
    //        transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
    //    }
    //}

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("JumpA");
            if (jumpsLeft > 0)
            {
                Debug.Log("JumpB");
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                jumpsLeft--;
            }
        }
    }

    //public void CheckIfGrounded()
    //{
    //    Collider2D c2d = Physics2D.OverlapCircle(GroundCheck.position, groundCollider.radius, GroundLayer);
    //    if (c2d!= null)
    //    {
    //        Debug.Log("CheckIfGrounded " + c2d.name);
    //        isGrounded = true;
    //    }
    //}

    public void ResetJumps()
    {
        Debug.Log("ResetJumps");
        jumpsLeft = jumpsAmount;// jumpsAmount =2;
    }

    public void DealDamage(int v)
    {
        healthPoints -= v;
        sr.color = Color.magenta;
        Debug.Log("Received Damage " + v);
        if (healthPoints <= 0)
        {
            // Die
            Debug.Log("DIED!!!");
        }
        else
        {
            Invoke(nameof(ClearHurt), 0.5f);
        }
    }

    public void ClearHurt()
    {
        sr.color = Color.white;
    }
}