using System;
using UnityEngine;

public class PlayerCombatManager : MonoBehaviour
{
    [HideInInspector] public PlayerManager player;
    public WeaponManager currentWeaponManager;
    public WeaponItem currentWeaponItem;
    public GameObject currentDrawProjectileModel;

    private void Awake()
    {
        player = GetComponent<PlayerManager>();
    }

    public void PerformWeaponBasedAction()
    {
        if (currentWeaponItem == null) return;
        
        currentWeaponItem.AttemptToPerformAction(player);
    }

    public void StartWeaponBasedAction()
    {
        if (currentWeaponItem == null) return;
        
        currentWeaponItem.StartToPerformAction(player);
    }
}
