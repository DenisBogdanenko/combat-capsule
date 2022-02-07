using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public Vector3 leftEuler;
    public Vector3 rightEuler;
    public float rotationSpeed = 5f;

    private Transform _playerTransform;
    private Vector3 _targetEuler;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    void Update()
    {
        if (transform.position.x < _playerTransform.position.x)
        {
            _targetEuler = rightEuler;
        }
        else
        {
            _targetEuler = leftEuler;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(_targetEuler), Time.deltaTime * rotationSpeed);
    }
}
