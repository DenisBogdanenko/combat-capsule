using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody henRigidbody;
    public float speed = 3;
    public float timeToReachSpeed = 1;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;

        Vector3 force = henRigidbody.mass * (toPlayer * speed - henRigidbody.velocity) / timeToReachSpeed;
        henRigidbody.AddForce(force);
    }
}
