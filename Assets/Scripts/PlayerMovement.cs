using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float speed;
    
    [SerializeField] private int maxJumps;
    [SerializeField] private int jumpCount;

    [SerializeField] private float glidingSpeed;
    private float initialGravityScale;


    private void Awake()
    {
        

        // Grab references for rigidbody and animator for object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        initialGravityScale = body.gravityScale;

    }

    private void Update()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        // Left-Right Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        // Flip player movement when moving left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);

        }


        // Jump/Double Jump
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        // Reset jump count
        if (isGrounded())
        {
            jumpCount = 0;
        }


        // Gliding movement

        // Check if in air and moving downwards
        if (Input.GetKey(KeyCode.Space) || (Input.GetKey(KeyCode.LeftShift)) &&          
            (body.velocity.y <= 0) && !isGrounded())

        //remove gravity and change velocity to descend at -glidingSpeed
        {
            body.gravityScale = 0;
            body.velocity = new Vector2(body.velocity.x, -glidingSpeed);
        }
        // reset gravityScale
        else
        {
            body.gravityScale = initialGravityScale;
        }


        // Set animator parameters
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        // Jump Logic
        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("jump");
        }
        else if (!isGrounded() && jumpCount < 1)
        {
            body.velocity = new Vector2(body.velocity.x, speed);
            anim.SetTrigger("jump");
            jumpCount++;
        }
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider !=null;
    }
}
