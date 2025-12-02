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

    public override void StartWeaponBasedAction()
    {
        base.StartWeaponBasedAction();
        
        //TODO CALCULATE DURATION
        
        CanvasManager.Instance.StartCircleProgress(1f);
    }

    public override void PerformWeaponBasedAction()
    {
        base.PerformWeaponBasedAction();
        CanvasManager.Instance.StopCircleProgress();
    }
}
