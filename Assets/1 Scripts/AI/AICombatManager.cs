using System;
using UnityEngine;


public class AICombatManager : CharacterCombatManager
{
    [HideInInspector] public AICharacterManager aiManager;
    public float attackRange;
    public float targetToDistance;

    protected override void Awake()
    {
        base.Awake();
        aiManager = GetComponent<AICharacterManager>();
    }

    private void Update()
    {
        if (aiManager.currentTarget == null) return;
        
        targetToDistance = Vector3.Distance(aiManager.currentTarget.position, transform.position);
        if (targetToDistance < attackRange)
        {
            PerformWeaponBasedAction();
            //NEED ATTACK RATE
        }
    }
}