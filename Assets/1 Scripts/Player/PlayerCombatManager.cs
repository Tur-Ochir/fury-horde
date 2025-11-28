using System;
using UnityEngine;

public class PlayerCombatManager : CharacterCombatManager
{
    [HideInInspector] public PlayerManager player;

    protected override void Awake()
    {
        base.Awake();
        
        player = GetComponent<PlayerManager>();
    }
}
