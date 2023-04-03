using System.Xml.Serialization;
using System.Runtime.CompilerServices;
using System.IO.Pipes;
// using System.ComponentModel.DataAnnotations.Schema;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float movementInput = 0;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 15f;

    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator anim;

    private enum MovementState {_idle, _run, _jump, _fall};
    // Start is called before the first frame update 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movementInput * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        updateAnimationState();

    }

    private void updateAnimationState()
    {
        MovementState movementState;

        // check for 'run' input
        if (movementInput > 0f)
        {
            movementState = MovementState._run;
            sprite.flipX = false;
        }
        else if (movementInput < 0f)
        {
            movementState = MovementState._run;
            sprite.flipX = true;
        }
        else
        { 
            movementState = MovementState._idle;
        }

        // check for 'jump' input with tolerance
        if (rb.velocity.y > .1f)
        {
            movementState = MovementState._jump;
        } 
        else if (rb.velocity.y < -.1f)
        {
            movementState = MovementState._fall;
        }
        anim.SetInteger("movementState", (int)movementState );
    }
}
