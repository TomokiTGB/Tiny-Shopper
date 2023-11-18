using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTopController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpingPower;
    public float horizontal;
    public float vertical;
    public bool isFacingRight;
    public bool isFacingUp;
    public bool isFacingDown;

    private Animator animator;
    private bool isWalking;

    Vector2 movement;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerTopMovement();
        HandleAnimation();
        //Flip();

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }

    void PlayerTopMovement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //isWalking = (horizontal != 0) ? true : false; //optional yung (parenthesis) nilagay ko lang para di malito


    }

    void HandleAnimation()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    /*void Flip()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal >0f) //flip to left || flip to right
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }*/

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed); //rb.velocity.x/y yung default
    }

    public void LateUpdate()
    {
        
    }

}
