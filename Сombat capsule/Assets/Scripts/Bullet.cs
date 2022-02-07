using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject effectPrefab;

    void Start()
    {
        Destroy(gameObject, 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
