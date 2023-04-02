// using System.ComponentModel.DataAnnotations.Schema;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveInput = 0;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;

    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;
    // Start is called before the first frame update 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        updateAnimation();

    }


    private void updateAnimation()
    {
        if (moveInput > 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (moveInput < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else 
        anim.SetBool("running", false);
    }
}
