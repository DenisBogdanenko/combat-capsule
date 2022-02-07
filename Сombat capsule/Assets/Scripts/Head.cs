using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    public Transform headTarget;

    void Update()
    {
        transform.position = headTarget.position;
    }
}
