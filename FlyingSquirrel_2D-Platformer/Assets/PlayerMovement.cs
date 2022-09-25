using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;


    const float groundCheckRadius = 0.2f;
    private bool moving = false;

    private bool doubleJump; 
    private bool jumping;
    private bool isGrounded;
    private float jumpTime;
    private float jumpForce;
    private float buttonTime = 0.3f;
    private float jumpCount = 0;

    private float jumpAmount = 10;
    private float gravityScale = 1;
    private float fallingGravityScale = 1.75f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // initial jump
        if(jumpCount < 2) 
        {
            
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                jumping = true;
                jumpTime = 0;
            }

            if(rb.velocity.y >= 0)
            {
                rb.gravityScale = gravityScale;
            } 
            else if (rb.velocity.y < 0)
            {
                rb.gravityScale = fallingGravityScale;
            }

            if(jumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
                jumpTime += Time.deltaTime;
            }

            if(Input.GetKeyUp(KeyCode.UpArrow) || jumpTime > buttonTime)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpAmount * -1);
                jumping = false;
            }
            jumpCount++;
        }

        if (IsGrounded()) {
            jumpCount = 0;
        }

        

    }

    private bool IsGrounded()
    {
        isGrounded = false;
        //Check if the GroundCheckObject is colliding wiht other
        //2D Colliders that are in the "Ground" layer
        //If yes (isGrounded = true), if no (isGrounded = false)
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if(colliders.Length > 0)
        {
            isGrounded = true;
        }
        return isGrounded;
    }
}