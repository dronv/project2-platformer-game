using System.Xml.Serialization;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//handles all Player movement
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private LayerMask jumpableGround;
    private float movementInput = 0;

    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Animator anim;

    private enum MovementState { _idle, _run, _jump, _fall };
    [SerializeField] private AudioSource jumping_sound;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        movementInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movementInput * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        updateAnimationState();

    }

    // Player animation based on state(_idle, _run, _jump, _fall)
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
            jumping_sound.Play();
            movementState = MovementState._jump;
        }
        else if (rb.velocity.y < -.1f)
        {
            movementState = MovementState._fall;
        }
        anim.SetInteger("movementState", (int)movementState);
    }

    // Player needs to touch the ground before beeing able to jump again
    // TODO : Doublejump
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
