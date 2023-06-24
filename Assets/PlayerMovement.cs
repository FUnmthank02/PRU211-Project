using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float moveHoz;
    private float moveVer;
    private float moveSpeed = 2.5f;
    [SerializeField] float jumpForce = 3;
    Rigidbody2D rb;
    public Animator animator;
    bool isJumping = false;
    bool facingRight = true;
    static int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHoz = Input.GetAxis("Horizontal");
        moveVer = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", Math.Abs(moveHoz));
        if (moveHoz != 0)
        {
            transform.position += new Vector3(moveHoz * moveSpeed * Time.deltaTime, 0, 0);
            animator.SetFloat("Speed", 1);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);

        }
        else
        {
            animator.SetBool("IsJumping", false);

        }
        if (Input.GetButtonDown("Fire2"))
        {
            animator.SetBool("IsDefending", true);
        }
        else
        {
            animator.SetBool("IsDefending", false);
        }
        if (moveHoz > 0 && !facingRight)
        {
            Flip();
        }
        if (moveHoz < 0 && facingRight)
        {
            Flip();
        }
        //if (Input.GetButtonDown("Fire3"))
        //{
        //    animator.SetBool("IsAttacking", true);
        //}
        //else
        //{
        //    animator.SetBool("IsAttacking", false);

        //}
        Slide();


    }
    void Slide()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsSliding", true);
            jumpCount++;
        }
        else
        {
            animator.SetBool("IsSliding", false);
            jumpCount--;

        }
    }
    void Flip()
    {
        //Vector3 currentScale = gameObject.transform.localScale;
        //currentScale.x *= -1;
        //gameObject.transform.localScale = currentScale;
        transform.Rotate(0f, 180, 0f);
        facingRight = !facingRight;
    }

}
