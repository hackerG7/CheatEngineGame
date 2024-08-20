using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class FakeHeight2DHitBounce : MonoBehaviour
{
    public float verticalVelocityLoss;

    private Vector2 lastVerticalVelocity;


    public void Bounce()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.y <= 0) // Only bounce if moving downwards
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y * verticalVelocityLoss);
            GetComponent<FakeHeight2D>().ResetGrounded();
        }
    }
    public void Slide()
    {
        //rb.velocity = new Vector2(rb.velocity.x, 0);
    }
}
