using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Movement
    public Rigidbody2D rb;
    public float speed;
    float moveVelocity;
 

    void Update () 
    {
        moveVelocity = 0;

        if (Input.GetKey (KeyCode.LeftArrow)) {
            moveVelocity = -speed;
        }
        if (Input.GetKey (KeyCode.RightArrow)) {
            moveVelocity = speed;
        }

        rb.velocity = new Vector2 (moveVelocity, rb.velocity.y);

    }

}
