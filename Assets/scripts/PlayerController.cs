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

        // Iterate through child objects and prevent flipping for tagged ones
        foreach (Transform child in transform)
        {
            if (child.CompareTag("NoFlip"))
            {
                Vector3 childScale = child.localScale;
                childScale.x *= -1f; // Revert the flip
                child.localScale = childScale;
            }
        }
    }
}


}
