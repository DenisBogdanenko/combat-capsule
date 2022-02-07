using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public bool dieOnAnyCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            if (collision.rigidbody.GetComponent<Bullet>())
            {
                enemyHealth.TakeDamage(1);
            }
        }

        if (dieOnAnyCollision == true)
        {
            enemyHealth.TakeDamage(999);
        }
    }
}
