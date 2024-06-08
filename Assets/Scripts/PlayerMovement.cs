using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private new BoxCollider2D collider;
    private PlayerInput playerInput;
    [SerializeField] private LayerMask platformLayerMask;
    private float horizontalInput;
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpSpeed;
    private bool canDoubleJump;
    
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    private bool canDash;

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
        playerInput = GetComponent<PlayerInput>();
        canDash = true;
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

    public void OnMovementKeyPressed(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    public void OnJumpKeyPressed(InputAction.CallbackContext context)
    {
        if(!context.performed)
        {
            return;
        }
        
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
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpSpeed);
    }

    public void OnDashKeyPressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(canDash)
            {
                StartCoroutine(Dash());
            }
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        playerInput.currentActionMap.Disable();
        float gravityAtDashStart = rigidbody.gravityScale;
        rigidbody.gravityScale = 0;
        rigidbody.velocity = new Vector2(dashSpeed, 0);
        yield return new WaitForSeconds(dashDuration);
        
        rigidbody.gravityScale = gravityAtDashStart;
        playerInput.currentActionMap.Enable();
        yield return new WaitForSeconds(dashCooldown);
        
        canDash = true;
    }
}