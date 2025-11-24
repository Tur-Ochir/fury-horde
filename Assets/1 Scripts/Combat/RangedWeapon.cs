using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Ranged Weapon", order = 0)]
public class RangedWeapon : WeaponItem
{
    //NEED STAMINA
    public ProjectileItem currentProjectile;
    [Header("RangedSFX")]
    public AudioClip[] drawSounds;
    public AudioClip[] releaseSounds;
    public override void AttemptToPerformAction(PlayerManager actionPerformer)
    {
        //NEED SPAWN POINT
        //NEED FIRE DIRECTION
        //NEED POWER 
        var a = Instantiate(currentProjectile.releaseProjectileModel, actionPerformer.playerCombat.currentWeaponManager.spawnPoint.position, Quaternion.identity);
        a.Initialize(currentProjectile);
        a.rb.AddForce(a.transform.forward * currentProjectile.forwardVelocity);
    }
}