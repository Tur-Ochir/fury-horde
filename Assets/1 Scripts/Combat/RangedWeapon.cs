using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(menuName = "Weapon/Ranged Weapon", order = 0)]
public class RangedWeapon : WeaponItem
{
    public ProjectileItem currentProjectile;
    public float maxPower = 1;
    public float minPower = 1;
    public float speed = 1;
    [Header("RangedSFX")]
    public AudioClip[] drawSounds;
    public AudioClip[] releaseSounds;
    
    public override void StartToPerformAction(CharacterManager actionPerformer)
    {
        var a = Instantiate(currentProjectile.drawProjectileModel, actionPerformer.characterCombatManager.currentWeaponManager.spawnPoint.position, Quaternion.identity);
        a.transform.SetParent(actionPerformer.characterCombatManager.currentWeaponManager.spawnPoint);
        a.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
        
        actionPerformer.characterCombatManager.currentDrawProjectileModel = a;
        actionPerformer.characterCombatManager.speedOfProjectile = speed;
        actionPerformer.characterCombatManager.minPowerOfProjectile = minPower;
        actionPerformer.characterCombatManager.maxPowerOfProjectile = maxPower;
        actionPerformer.characterCombatManager.drawingProjectile = true;
    }
    public override void AttemptToPerformAction(CharacterManager actionPerformer)
    {
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
        var power = actionPerformer.characterCombatManager.currentPowerOfProjectile;
        a.Initialize(currentProjectile, power);
        Vector3 force = direction * currentProjectile.forwardVelocity * power;
        a.rb.AddForce(force, ForceMode.VelocityChange);
        
        PlaySFX(actionPerformer);
        
        actionPerformer.characterCombatManager.drawingProjectile = false; 
        actionPerformer.characterCombatManager.currentPowerOfProjectile = 0; 
    }

    private void PlaySFX(CharacterManager actionPerformer)
    {
        actionPerformer.characterEffectManager.PlaySFX(releaseSounds[Random.Range(0, releaseSounds.Length)]);
    }
}