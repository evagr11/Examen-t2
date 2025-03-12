using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Gradient healthGradient;
    public float currentHealth;
    [SerializeField] private float maxHealthValue;
    public float attackDamage = 2;

    private void Start()
    {
        currentHealth = maxHealthValue;
        UpdateHealthIndicator();
    }

    private void Update()
    {
        UpdateHealthIndicator();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            TriggerDeathSequence();
        }
    }

    private void UpdateHealthIndicator()
    {
        spriteRenderer.color = healthGradient.Evaluate(currentHealth / maxHealthValue);
    }

    

    private void TriggerDeathSequence()
    {
        GameEvents.EnemyDied.Invoke();
    }
}