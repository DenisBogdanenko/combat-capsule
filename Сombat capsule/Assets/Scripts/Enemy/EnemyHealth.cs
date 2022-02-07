using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;
    public UnityEvent eventOnTakeDamage;
    public UnityEvent eventOnDie;

    public void TakeDamage(int damageValue)
    {
        health -= damageValue;
        eventOnTakeDamage.Invoke();

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        eventOnDie.Invoke();
        Destroy(gameObject);
    }
}
