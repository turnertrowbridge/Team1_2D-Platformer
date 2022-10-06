using UnityEngine;

public class NewJump : MonoBehaviour
{
    [SerializeField] public LayerMask groundLayer;

    [SerializeField] public float glidingSpeed;
    public float _initialgravityScale;

    public BoxCollider2D boxCollider;
    public Rigidbody2D rb1;
    public float jump;
    int jumpCount = 0;

    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
        _initialgravityScale = rb1.gravityScale;
        boxCollider = GetComponent<BoxCollider2D>();

    }
    // Update is called once per frame
    void Update()
    {
        var glidingInput = Input.GetButton("Jump");

        if (glidingInput && rb1.velocity.y <= 0 && jumpCount > 0)
        {
            rb1.gravityScale = 0;
            rb1.velocity = new Vector2(rb1.velocity.x, -glidingSpeed);
        }
        else
        {
            rb1.gravityScale = _initialgravityScale;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGrounded() || jumpCount < 1))
        {
            rb1.velocity = new Vector2(rb1.velocity.x, jump);
            jumpCount++;
        }

        if (isGrounded())
        {
            jumpCount = 0;
        }
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
}
