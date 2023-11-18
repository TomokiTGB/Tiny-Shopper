using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float jumpingPower;
    public float horizontal;
    public bool isFacingRight;

    private Animator animator;
    private bool isWalking;
    private bool isJumping;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isCrouching;

    //Collect Item
    public bool collected;
    public int sceneName;
    public int death;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        death = 0;
    }

    void Update()
    {
        PlayerMovement();
        HandleAnimation();
        Flip();
    }

    void PlayerMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) // If Button Hit and is player grounded
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower); // JUMP
        }
        isJumping = (rb.velocity.y != 0) ? true : false;
        isWalking = (horizontal != 0) ? true : false; //optional yung (parenthesis) nilagay ko lang para di malito
        isCrouching = (Input.GetKey(KeyCode.DownArrow) && IsGrounded() && death == 0) ? true : false;
        
    }

    void HandleAnimation()
    {
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isCrouching", isCrouching);
    }

    void Flip()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal >0f) //flip to left || flipt to right
        {
            isFacingRight = !isFacingRight;
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void LateUpdate()
    {
        
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //collect item
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Collect") //check if player collides to an object
        {
            Destroy(collision.gameObject);
            collected = true;
        }

        if (collision.gameObject.tag == "Door" && collected == true) //check if player collides to an object
        {
            SceneManager.LoadScene(sceneName);
        }
        
        
    }

    //Enemy Caught
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isCrouching)
        {
            Debug.Log("Caught");
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        animator.SetTrigger("death");
        death = 1;
    }
    
    //Restart

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
