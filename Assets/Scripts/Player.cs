using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speedMove = 5f;
    public float jumpForce = 350f;
    public LayerMask groundLayers;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public bool isOnGround;
    private Rigidbody2D rb;
    private bool isLookRight = true;
    public Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Turn()
    {
        isLookRight = !isLookRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;        
        transform.localScale = scale;

    }

     void Update()
    {
        isOnGround = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, groundLayers);

        for (int i = 0; i < colliders.Length; i++)
        {            
            if (colliders[i].gameObject != gameObject)
            {
                isOnGround = true;
                animator.SetBool("isJumping", false);
                if (animator.GetBool("isDead") == false)
                    animator.SetBool("isIdle", true);
            }
        }

        if (animator.GetBool("isDead") == false)
        {
            float direction = Input.GetAxisRaw("Horizontal");

            rb.velocity = new Vector2(direction * speedMove, rb.velocity.y);

            if (rb.velocity.x > 0.0f || rb.velocity.x < 0.0f)
            {
                animator.SetBool("isJumping", false);
                animator.SetBool("isIdle", false);
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isJumping", false);
                if (animator.GetBool("isDead") == false)
                    animator.SetBool("isIdle", true);
                animator.SetBool("isRunning", false);
            }

            if (direction > 0 && !isLookRight)
            {
                Turn();
            }
            else if (direction < 0 && isLookRight)
            {
                Turn();
            }

            // SE APERTA PRA PULAR, E ESTA NO CHÃO
            if (Input.GetButtonDown("Jump") && isOnGround)
            {
                isOnGround = false;
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                animator.SetBool("isJumping", true);
                animator.SetBool("isIdle", false);
                animator.SetBool("isRunning", false);
            }
        }
        
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isIdle", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isDead", true);
        }
    }
    

}
