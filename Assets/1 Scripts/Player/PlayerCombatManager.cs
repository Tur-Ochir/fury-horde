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
        
        float t = GetTimeToMaxPower();
        CanvasManager.Instance.StartCircleProgress(t);
    }

    public override void PerformWeaponBasedAction()
    {
        base.PerformWeaponBasedAction();
        
        CanvasManager.Instance.StopCircleProgress();
    }
    public float GetTimeToMaxPower()
    {
        return (maxPowerOfProjectile - minPowerOfProjectile) / speedOfProjectile;
    }
}
