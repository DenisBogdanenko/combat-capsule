using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int healthValue = 1;
    public float rotationSpeed = 10;

    private void Update()
    {
        transform.Rotate(0, 10 * Time.deltaTime * rotationSpeed, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            other.attachedRigidbody.GetComponent<PlayerHealth>().AddHealth(healthValue);
            Destroy(gameObject);
        }
    }
}
