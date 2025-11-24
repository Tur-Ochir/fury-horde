using UnityEngine;


[CreateAssetMenu(menuName = "Weapon/Projectile", order = 0)]
public class ProjectileItem : ScriptableObject
{
    [Header("Velocity")]
    public float forwardVelocity = 2200;
    public float upwardVelocity = 0;
    public float ammoPass = 0.01f;
    
    [Header("Damage")]
    public int physicalDamage = 0;
    public int fireDamage = 0;
    
    [Header("Model")]
    public GameObject drawProjectileModel;
    public Arrow releaseProjectileModel;
}