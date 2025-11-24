using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public float physicalDamage;
    public float fireDamage;
    
    public Collider damageCollider;
    // protected List<CharacterManager> charactersDamaged = new List<CharacterManager>();
    protected Vector3 contactPoint;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(physicalDamage);
        }
    }
}
