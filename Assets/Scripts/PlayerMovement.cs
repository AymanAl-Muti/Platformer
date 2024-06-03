using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private new BoxCollider2D collider;
    [SerializeField] private LayerMask platformLayerMask;
    private float horizontalInput;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    private bool canDoubleJump;

    private bool IsGrounded => Physics2D.BoxCast
        (
            collider.bounds.center,
            collider.bounds.size,
            0,
            Vector2.down,
            0.1f,
            platformLayerMask
        );
    
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(IsGrounded)
        {
            canDoubleJump = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(horizontalInput * moveSpeed, rigidbody.velocity.y);
    }

    private void TryJump()
    {
        if(IsGrounded)
        {
            Jump();
        }
        else if(canDoubleJump)
        {
            canDoubleJump = false;
            Jump();
        }
    }

    private void Jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
    }
}
