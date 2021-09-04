using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 5;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGrounded;

    private Rigidbody2D rb;
    public bool isGrounded { get; set; }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Jump()
    {
        if(isGrounded)
        {  
            rb.velocity = Vector2.up * jumpForce;
        } 
    }

    public void MoveHorizontal(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGrounded);
    }

}
