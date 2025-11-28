using System;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [HideInInspector] private CharacterManager character;
    public float health = 100;
    public float maxHealth = 100;
    
    public UnityAction<float, float> OnHealthChanged;

    private void Awake()
    {
        character = GetComponent<CharacterManager>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            character.isDead = true;
            character.OnDeath?.Invoke();
        }
        
        OnHealthChanged?.Invoke(maxHealth, health);
    }
}