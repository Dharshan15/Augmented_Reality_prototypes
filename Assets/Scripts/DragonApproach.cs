using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonApproach : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform target; // The target is automatically found in the script.

    private Rigidbody rigidBody;

    private void OnEnable()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        target = FindObjectOfType<Camera>().transform; // Automatically find the AR camera.
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 directionToTarget = target.position - transform.position;
            directionToTarget.Normalize();

            float xVal = directionToTarget.x;
            float zVal = directionToTarget.z; // Use z-axis for forward/backward movement.

            Vector3 movement = new Vector3(xVal, 0, zVal);

            rigidBody.velocity = movement * speed;

            if (xVal != 0 || zVal != 0)
            {
                // Calculate the rotation to face the target.
                float angle = Mathf.Atan2(xVal, zVal) * Mathf.Rad2Deg;
                Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
            }
        }
        else
        {
            Debug.LogWarning("AR Camera not found. Make sure you have an AR camera in the scene.");
        }
    }
}
