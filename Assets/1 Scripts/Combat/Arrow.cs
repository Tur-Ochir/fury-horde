using UnityEngine;


public class Arrow : MonoBehaviour
{
    public DamageCollider damageCollider;
    public Rigidbody rb;
    
    public void Initialize(ProjectileItem projectile)
    {
        damageCollider.physicalDamage = projectile.physicalDamage;
        damageCollider.fireDamage = projectile.fireDamage;
    }
}