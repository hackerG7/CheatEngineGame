using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerWithSpeed : MonoBehaviour
{
    // The target to follow
    public Transform target;

    // Lerp speeds for each axis
    public float lerpSpeedX = 5f;
    public float lerpSpeedY = 5f;
    public float lerpSpeedZ = 5f;

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Target not set!");
            return;
        }

        // Current position of the follower
        Vector3 currentPosition = transform.position;

        // Target position
        Vector3 targetPosition = target.position;

        // Calculate the new position using Lerp for each axis individually
        float newX = Mathf.Lerp(currentPosition.x, targetPosition.x, lerpSpeedX * Time.deltaTime);
        float newY = Mathf.Lerp(currentPosition.y, targetPosition.y, lerpSpeedY * Time.deltaTime);
        float newZ = Mathf.Lerp(currentPosition.z, targetPosition.z, lerpSpeedZ * Time.deltaTime);

        // Set the new position
        transform.position = new Vector3(newX, newY, newZ);
    }
}
