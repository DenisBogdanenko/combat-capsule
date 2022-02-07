using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public bool dieOnAnyCollision = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
            }
        }

        if (dieOnAnyCollision == true)
        {
            if (other.isTrigger == false)
            {
                enemyHealth.TakeDamage(999);
            }
        }
    }
}
