using System;
using UnityEngine;

public class PlayerCombatManager : MonoBehaviour
{
    [HideInInspector] public PlayerManager player;
    public WeaponManager currentWeaponManager;
    public WeaponItem currentWeaponItem;

    private void Awake()
    {
        player = GetComponent<PlayerManager>();
    }

    public void PerformWeaponBasedAction()
    {
        if (currentWeaponItem == null) return;
        
        currentWeaponItem.AttemptToPerformAction(player);
    }
}
