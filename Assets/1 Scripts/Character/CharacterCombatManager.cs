using System;
using UnityEngine;

public class CharacterCombatManager : MonoBehaviour
{
    [HideInInspector] public CharacterManager character;
    public WeaponManager currentWeaponManager;
    public WeaponItem currentWeaponItem;
    public GameObject currentDrawProjectileModel;
    public float currentPowerOfProjectile;
    public float speedOfProjectile;
    public float maxPowerOfProjectile;
    public float minPowerOfProjectile;
    public bool drawingProjectile;

    protected virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
    }

    protected virtual void Update()
    {
        if (drawingProjectile)
        {
            currentPowerOfProjectile += speedOfProjectile * Time.fixedDeltaTime;
            Mathf.Clamp(currentPowerOfProjectile, minPowerOfProjectile, maxPowerOfProjectile);
        }
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