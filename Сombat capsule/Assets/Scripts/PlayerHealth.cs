using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    private bool _invulnerable = false;

    public HealthUI healthUI;
    public AudioSource addHealthSound;
    public int health = 5;
    public int maxHealth = 8;
    public UnityEvent eventOnTakeDamage;

    private void Start()
    {
        healthUI.SetUp(maxHealth);
        healthUI.DisplayHealth(health);
    }

    public void TakeDamage(int damageValue)
    {
        if (_invulnerable == false)
        {
            health -= damageValue;
            if (health <= 0)
            {
                health = 0;
                Die();
            }
            _invulnerable = true;
            Invoke("StopInvulnerable", 1);
            healthUI.DisplayHealth(health);

            eventOnTakeDamage.Invoke();
        }
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddHealth(int healthValue)
    {
        health += healthValue;
        addHealthSound.Play();
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        healthUI.DisplayHealth(health);
    }
}
