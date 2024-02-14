using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoroCube : MonoBehaviour
{
    private Rigidbody rb;
    private float destroyTimer = 8.0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
    }

    void Update()
    {
        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoroCube : MonoBehaviour
{
    private Rigidbody rb;
    public Transform target; // Drag and drop the target object (e.g., the camera) in the Inspector.

    private float destroyTimer = 8.0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        if (target != null)
        {
            Vector3 directionToTarget = target.position - transform.position;
            directionToTarget.Normalize(); // Normalize the vector to make it a unit vector.
            rb.AddForce(directionToTarget * 5, ForceMode.Impulse); // Adjust the force as needed.
        }
        else
        {
            Debug.LogWarning("Target is not assigned. Please assign a target in the Inspector.");
        }
    }

    void Update()
    {
        destroyTimer -= Time.deltaTime;

        if (destroyTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
*/