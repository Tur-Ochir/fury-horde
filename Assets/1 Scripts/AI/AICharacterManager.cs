using System;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterManager : CharacterManager
{
    [HideInInspector] public NavMeshAgent agent;
    public Transform currentTarget;

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    protected override void OnEnable()
    {
        base.OnEnable();    
        OnDeath += Die;
    }
    void Die()
    {
        agent.enabled = false;
        Destroy(gameObject, 0.1f);
    }
    protected override void Update()
    {
        if (!agent.enabled) return;
        if (isPerformingAction) return;
        
        ChaseTarget();
    }

    private void ChaseTarget()
    {
        Move(currentTarget.position);
    }

    private void Move(Vector3 target)
    {
        if (!canMove) return;
        
        agent.SetDestination(target);
    }
}