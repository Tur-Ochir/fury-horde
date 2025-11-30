using System;
using UnityEngine;

public class AICharacterAnimationManager : CharacterAnimationManager
{
    [HideInInspector] public AICharacterManager aiManager;
    
    protected override void Awake()
    {
        base.Awake();
        aiManager = GetComponent<AICharacterManager>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", aiManager.agent.velocity.magnitude);
    }
}