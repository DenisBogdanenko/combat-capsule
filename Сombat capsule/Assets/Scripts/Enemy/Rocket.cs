using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 5;
    public float rotationSpeed = 1;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * speed;
        Vector3 toPlayer = _playerTransform.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
}
