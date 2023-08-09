using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsEnemy : CoreComponent
{
    public event Action OnHealthZero;

    [SerializeField] private float maxHealth;
    public float currentHealth;
    public static bool isDeath = false;
    public static bool isHealth = false;

    protected override void Awake()
    {
        base.Awake();
        currentHealth = maxHealth;
    }

    public void DecreaseHealth(float amount)
    {
         currentHealth -= amount;
        if (currentHealth <= 0 )
        {
            currentHealth = 0;

            OnHealthZero?.Invoke();

            Debug.Log("Health is Zero!!");
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    public void ResetHealth(float health)
    {
        currentHealth = health;
        isHealth = true;
    }
}
