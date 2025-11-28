using System;
using UnityEngine;

public class Healthbar : ValueBar
{
    public Health health;

    private void OnEnable()
    {
        if (health == null) return;
        
        health.OnHealthChanged += UpdateHealthValue;
    }
    private void UpdateHealthValue(float max, float current)
    {
        UpdateValueBar(current, max);
    }
}