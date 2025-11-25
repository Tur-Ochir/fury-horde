using System;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterManager : CharacterManager
{
    [HideInInspector] public NavMeshAgent agent;
    public Transform player;

    protected override void Awake()
    {
        base.Awake();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        Move(player.position);
    }

    private void Move(Vector3 target)
    {
        agent.SetDestination(target);
    }
}