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
        //NEED FIRE DIRECTION
        //NEED POWER 
        if (actionPerformer.playerCombat.currentDrawProjectileModel != null)
        {
            Destroy(actionPerformer.playerCombat.currentDrawProjectileModel);
        }
        
        var a = Instantiate(currentProjectile.releaseProjectileModel, actionPerformer.playerCombat.currentWeaponManager.spawnPoint.position, Quaternion.identity);
        a.transform.SetParent(actionPerformer.playerCombat.currentWeaponManager.spawnPoint);
        a.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        a.Initialize(currentProjectile);
        a.rb.AddForce(a.transform.forward * currentProjectile.forwardVelocity, ForceMode.VelocityChange);
    }

    public override void StartToPerformAction(PlayerManager actionPerformer)
    {
        var a = Instantiate(currentProjectile.drawProjectileModel, actionPerformer.playerCombat.currentWeaponManager.spawnPoint.position, Quaternion.identity);
        a.transform.SetParent(actionPerformer.playerCombat.currentWeaponManager.spawnPoint);
        a.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        actionPerformer.playerCombat.currentDrawProjectileModel = a;
    }
}