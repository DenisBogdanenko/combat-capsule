using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Vector3 velocity;
    public float maxRotationSpeed;

    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(GetRandom(), GetRandom(), GetRandom());
    }

    private float GetRandom()
    {
        return Random.Range(-maxRotationSpeed, maxRotationSpeed);
    }
}
