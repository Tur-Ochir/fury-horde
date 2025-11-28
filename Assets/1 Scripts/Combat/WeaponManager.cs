using System;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Melee Weapon Manager")]
    public DamageCollider damageCollider;
    [Header("Ranged Weapon Manager")]
    public Transform spawnPoint;

    private void Awake()
    {
        damageCollider = GetComponentInChildren<DamageCollider>();
    }

    public void SetWeaponDamage(WeaponItem weapon)
    {
        damageCollider.physicalDamage = weapon.physicalDamage;
    }
}