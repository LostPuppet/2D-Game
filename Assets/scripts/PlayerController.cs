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

    [SerializeField] private float friction = 0.1f;
    private float maxVelocity = 5f; // Max allowed velocity before stopping acceleration

    void Start()
    {
        gravityScale = baseGravityScale;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        float currentVelocity = rb.linearVelocity.x;

        // Prevent acceleration if moving past max velocity in the same direction
        if ((horizontal > 0 && currentVelocity >= maxVelocity) || (horizontal < 0 && currentVelocity <= -maxVelocity))
        {
            horizontal = 0;
        }
        
        bool grounded = IsGrounded();
        gravityScale = baseGravityScale;
        ApplyFriction();
        rb.gravityScale = gravityScale;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
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
        rb.AddForce(new Vector2(horizontal * speed, 0), ForceMode2D.Force);
    }

    private bool IsGrounded()
    {
        float checkRadius = 0.2f;
        Collider2D groundCollider = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
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

            foreach (Transform child in transform)
            {
                if (child.CompareTag("NoFlip"))
                {
                    Vector3 childScale = child.localScale;
                    childScale.x *= -1f;
                    child.localScale = childScale;
                }
            }
        }
    }

    private void ApplyFriction()
    {
        if (Mathf.Abs(rb.linearVelocity.x) > 0)
        {
            float frictionForce = Mathf.Sign(rb.linearVelocity.x) * friction;
            rb.AddForce(new Vector2(-frictionForce, 0), ForceMode2D.Force);
        }
    }
}
