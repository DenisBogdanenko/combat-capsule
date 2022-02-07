using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public Rigidbody carrotRigidbody;
    public float speed;

    void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        carrotRigidbody.velocity = toPlayer * speed;
    }
}
