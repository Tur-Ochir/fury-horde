using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector] private CharacterManager character;
    public float health = 100;

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
    }
}