using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private new BoxCollider2D collider;
    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private bool canDoubleJump;
    private float horizontalInput;

    private bool IsGrounded => Physics2D.BoxCast(
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
        if(IsGrounded)
        {
            canDoubleJump = true;
        }
    }

    private void FixedUpdate()
    {
        if(horizontalInput != 0)
        {
            rigidbody.velocity = new Vector2(horizontalInput * moveSpeed, rigidbody.velocity.y);
        }
    }

    public void HandleMovement(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    public void TryJump(InputAction.CallbackContext context)
    {
        if(context.performed)
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
    }

    private void Jump()
    {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
    }
}