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
        Debug.Log($"DAMAGE COLLIDER TRIGGERED {other.transform.root.name}");
        if (other.transform.root.TryGetComponent(out CharacterManager character))
        {
            contactPoint = other.ClosestPointOnBounds(transform.position);
            TakeDamageEffect takeDamageEffect = character.characterEffectManager.takeDamageEffect; //GET DAMAGE EFFECT
            takeDamageEffect.physicalDamage = physicalDamage;
            takeDamageEffect.contactPoint = contactPoint;

            takeDamageEffect.ProcessEffect(character);
            // Destroy(gameObject);
        }
        
    }
}
