using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FakeHeight2D : MonoBehaviour
{
    public UnityEvent OnGroundHitEvent;
    public Transform transformBody;
    public Transform targetTransformGround;

    private bool isGrounded = true;

    // Start is called before the first frame update
    private void Update()
    {
        CheckGroundHit();
    }
    private void CheckGroundHit()
    {
        if (transformBody.position.y < targetTransformGround.position.y && isGrounded)
        {
            isGrounded = true;
            OnGroundHitEvent.Invoke();
        }
    }
    public void ResetGrounded()
    {
        isGrounded = false;
    }
}
