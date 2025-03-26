using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isFacingRight = true;
    
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    [SerializeField] private float baseGravityScale = 1f;
    private float gravityScale;
    [SerializeField] private float maxGravityScale = 3f;
    [SerializeField] private float gravityIncreaseRate = 0.1f;
    
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        gravityScale = baseGravityScale;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        bool grounded = IsGrounded();
        Debug.Log("IsGrounded: " + grounded);

        if (grounded)
        {
            gravityScale = baseGravityScale;
        }
        else
        {
            gravityScale = Mathf.Min(gravityScale + gravityIncreaseRate * Time.deltaTime, maxGravityScale);
        }
        rb.gravityScale = gravityScale;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("Jumping!");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {  
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
    }

    private bool IsGrounded()
    {
        float checkRadius = 0.2f;
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        if (groundCollider != null)
        {
            Debug.Log("Ground detected: " + groundCollider.gameObject.name);
        }
        else
        {
            Debug.Log("Not grounded! Check position, layer, and collider.");
        }

        return groundCollider != null;
    }

    private void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
