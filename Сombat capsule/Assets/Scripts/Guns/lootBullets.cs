using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootBullets : MonoBehaviour
{
    public int gunIndex;
    public int numberOfBullets = 20;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerArmory>())
        {
            other.attachedRigidbody.GetComponent<PlayerArmory>().AddBullets(gunIndex, numberOfBullets);
            Destroy(gameObject);
        }
    }
}
