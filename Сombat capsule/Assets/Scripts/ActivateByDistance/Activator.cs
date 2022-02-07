using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateByDistance> objectsToActivate = new List<ActivateByDistance>();
    public Transform playerTransform;

    void Update()
    {
        for (int i = 0; i < objectsToActivate.Count; i++)
        {
            objectsToActivate[i].CheckDistance(playerTransform.position);
        }
    }
}
