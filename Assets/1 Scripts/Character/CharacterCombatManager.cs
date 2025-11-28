using System;
using UnityEngine;

public class CharacterCombatManager : MonoBehaviour
{
    [HideInInspector] public CharacterManager character;
    public WeaponManager currentWeaponManager;
    public WeaponItem currentWeaponItem;
    public GameObject currentDrawProjectileModel;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
    }
    public virtual void PerformWeaponBasedAction()
    {
        if (currentWeaponItem == null) return;
        
        currentWeaponItem.AttemptToPerformAction(character);
    }

    public virtual void StartWeaponBasedAction()
    {
        if (currentWeaponItem == null) return;
        
        currentWeaponItem.StartToPerformAction(character);
    }
}