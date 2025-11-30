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

    public void Initialize(ProjectileItem projectile)
    {
        damageCollider.physicalDamage = projectile.physicalDamage;
        damageCollider.fireDamage = projectile.fireDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        rb.isKinematic = true;
        damageCollider.enabled = false;
        // transform.SetParent(null);
    }
}