using System;
using UnityEngine;


public class Arrow : MonoBehaviour
{
    public DamageCollider damageCollider;
    public Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void Initialize(ProjectileItem projectile, float power)
    {
        damageCollider.physicalDamage = projectile.physicalDamage * power;
        damageCollider.fireDamage = projectile.fireDamage * power;
    }

    private void OnTriggerEnter(Collider other)
    {
        // rb.isKinematic = true;
        // damageCollider.canDamage = false;
        // damageCollider.enabled = false;
        // transform.SetParent(null);
    }
}