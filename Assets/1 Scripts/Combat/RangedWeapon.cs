using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Ranged Weapon", order = 0)]
public class RangedWeapon : WeaponItem
{
    //NEED STAMINA
    public ProjectileItem currentProjectile;
    [Header("RangedSFX")]
    public AudioClip[] drawSounds;
    public AudioClip[] releaseSounds;
    public override void AttemptToPerformAction(CharacterManager actionPerformer)
    {
        //NEED FIRE DIRECTION
        //NEED POWER 
        if (actionPerformer.characterCombatManager.currentDrawProjectileModel != null)
        {
            Destroy(actionPerformer.characterCombatManager.currentDrawProjectileModel);
        }

        Vector3 hitPoint = Vector3.zero;
        if (Physics.Raycast(actionPerformer.camTransform.position, actionPerformer.camTransform.forward,
                out RaycastHit hit, 999f))
        {
            hitPoint = hit.point;
        }
        
        Vector3 direction = hitPoint != Vector3.zero ? (hitPoint - actionPerformer.characterCombatManager.currentWeaponManager.spawnPoint.position) : actionPerformer.camTransform.forward;
        direction.Normalize();
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        
        var a = Instantiate(currentProjectile.releaseProjectileModel, actionPerformer.characterCombatManager.currentWeaponManager.spawnPoint.position, lookRotation);
        // a.transform.SetParent(actionPerformer.playerCombat.currentWeaponManager.spawnPoint);
        // a.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        
        a.Initialize(currentProjectile);
        a.rb.AddForce(direction * currentProjectile.forwardVelocity, ForceMode.VelocityChange);
        
        PlaySFX(actionPerformer);
    }

    private void PlaySFX(CharacterManager actionPerformer)
    {
        actionPerformer.characterEffectManager.PlaySFX(releaseSounds[Random.Range(0, releaseSounds.Length)]);
    }

    public override void StartToPerformAction(CharacterManager actionPerformer)
    {
        var a = Instantiate(currentProjectile.drawProjectileModel, actionPerformer.characterCombatManager.currentWeaponManager.spawnPoint.position, Quaternion.identity);
        a.transform.SetParent(actionPerformer.characterCombatManager.currentWeaponManager.spawnPoint);
        a.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        actionPerformer.characterCombatManager.currentDrawProjectileModel = a;
    }
}