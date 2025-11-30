using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour
{
    [HideInInspector] public Health health;
    [HideInInspector] public CharacterEffectManager characterEffectManager;
    [HideInInspector] public CharacterCombatManager characterCombatManager;
    [HideInInspector] public CharacterAnimationManager characterAnimationManager;
    public Transform camTransform;
    public bool isDead;
    public bool isPerformingAction;
    public bool canMove = true;
    public bool canRotate = true;
    
    public UnityAction OnDeath;

    protected virtual void Awake()
    {
        characterEffectManager = GetComponent<CharacterEffectManager>();
        characterCombatManager = GetComponent<CharacterCombatManager>();
        characterAnimationManager = GetComponent<CharacterAnimationManager>();
        health = GetComponent<Health>();
    }
    protected virtual void Start(){}
    protected virtual void Update(){}
    protected virtual void OnEnable(){}
    protected virtual void OnDisable(){}
}