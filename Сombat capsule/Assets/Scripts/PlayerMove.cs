using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody _rigidbody;

    public Transform colliderTransform;
    public Transform aim;

    public float moveSpeed;
    public float jumpSpeed;
    public float friction;
    public float maxSpeed;
    public bool isGrounded;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ROtateToAim();
        Jump();
        SitDown();

        if (isGrounded == false)
        {
            _rigidbody.freezeRotation = false;
            _rigidbody.AddTorque(0, 0, 100, ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        float speedMultiplier = 1f;

        if (!isGrounded)
        {
            speedMultiplier = 0.2f;

            if (_rigidbody.velocity.x > maxSpeed && Input.GetAxis("Horizontal") > 0)
            {
                speedMultiplier = 0;
            }

            if (_rigidbody.velocity.x < -maxSpeed && Input.GetAxis("Horizontal") < 0)
            {
                speedMultiplier = 0;
            }
        }

        _rigidbody.AddForce(Input.GetAxis("Horizontal") * moveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (isGrounded)
        {
            _rigidbody.AddForce(-_rigidbody.velocity.x * friction, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                JumpForce();
            }
        }
    }

    public void JumpForce()
    {
        _rigidbody.AddForce(0, jumpSpeed, 0, ForceMode.VelocityChange);
    }

    private void SitDown()
    {
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.S) || !isGrounded)
        {
            colliderTransform.localScale = Vector3.Lerp(colliderTransform.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 15);
        }
        else
        {
            colliderTransform.localScale = Vector3.Lerp(colliderTransform.localScale, new Vector3(1, 1, 1), Time.deltaTime * 15);
        }
    }

    private void ROtateToAim()
    {
        if (isGrounded)
        {
            Quaternion currentRotation = transform.rotation;
            float rotateSpeed = 700;

            if (aim.position.x > transform.position.x)
            {
                Quaternion wantedRotation = Quaternion.Euler(0, -45, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);
            }

            if (aim.position.x < transform.position.x)
            {
                Quaternion wantedRotation = Quaternion.Euler(0, 45, 0);
                transform.rotation = Quaternion.RotateTowards(currentRotation, wantedRotation, Time.deltaTime * rotateSpeed);
            }

        }
    }

    private void OnCollisionStay(Collision collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            float angle = Vector3.Angle(collision.contacts[i].normal, Vector3.up);
            if (angle < 45)
            {
                isGrounded = true;
                _rigidbody.freezeRotation = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
