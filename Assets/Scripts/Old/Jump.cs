using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] public LayerMask groundLayerMask;

    [SerializeField] public float glidingSpeed;
    public float _initialgravityScale;

    public CircleCollider2D circleCollider2d;
    public Rigidbody2D rb1;
    public float jump;
    int jumpCount = 0;

    void Start()
    {
        rb1 = GetComponent<Rigidbody2D>();
        _initialgravityScale = rb1.gravityScale;
    }
    // Update is called once per frame
    void Update()
    {
        var glidingInput = Input.GetButton("Jump");

        if(glidingInput && rb1.velocity.y <= 0 && jumpCount > 0) 
        {
            rb1.gravityScale = 0;
            rb1.velocity = new Vector2(rb1.velocity.x, -glidingSpeed);
        }
        else 
        {
            rb1.gravityScale = _initialgravityScale;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&& (isGrounded() || jumpCount < 1)) 
        {
            rb1.velocity = new Vector2 (rb1.velocity.x, jump);
            jumpCount++;
        }

        if (isGrounded()) 
        {
            jumpCount = 0;
        }
    }

    private bool isGrounded() 
    {
        float extraHeight = 0.01f;
        RaycastHit2D raycastHit = Physics2D.Raycast(circleCollider2d.bounds.center, Vector2.down, circleCollider2d.bounds.extents.y + extraHeight, groundLayerMask);            
        Color rayColor;

        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        } 
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(circleCollider2d.bounds.center, Vector2.down * (circleCollider2d.bounds.extents.y + extraHeight), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
}
