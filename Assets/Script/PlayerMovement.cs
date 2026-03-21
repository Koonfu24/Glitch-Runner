using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 15f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Simple ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        
        float direction = Mathf.Sign(rb.gravityScale);
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce * direction);
    }

}
