using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour
{
    [HideInInspector] public Health health;
    [HideInInspector] public CharacterEffectManager characterEffectManager;
    public bool isDead;

    protected virtual void Awake()
    {
        characterEffectManager = GetComponent<CharacterEffectManager>();
        health = GetComponent<Health>();
    }
}