using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Ranged Weapon", order = 0)]
public class RangedWeapon : WeaponItem
{
    public ProjectileItem currentProjectile;
    [Header("RangedSFX")]
    public AudioClip[] drawSounds;
    public AudioClip[] releaseSounds;
}