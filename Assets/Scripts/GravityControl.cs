using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControl : MonoBehaviour
{
    [SerializeField] public GravityOrbit gravity;
    private Rigidbody rigidbody;
    private Transform cam;
    private Quaternion targetRotation;

    [SerializeField] public float rotationSpeed = 20f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        UpdateGravity();
        RotatePlayer();
    }

    private void UpdateGravity()
    {
        if (gravity)
        {
            Vector3 gravityUp = Vector3.zero;

            if (gravity.fixedDirection)
            {
                gravityUp = gravity.transform.up;
            }
            else
            {
                gravityUp = (transform.position - gravity.transform.position).normalized;
            }

            Vector3 localUp = transform.up;

            targetRotation = Quaternion.FromToRotation(localUp, gravityUp) * transform.rotation;

            transform.up = Vector3.Lerp(transform.up, gravityUp, rotationSpeed * Time.deltaTime);

            rigidbody.AddForce((-gravityUp * gravity.Gravity) * rigidbody.mass);
        }
    }

    private void RotatePlayer()
    {
        if (gravity)
        {
            cam.rotation = targetRotation;
        }
    }
}
