using System;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    public bool canDamage = true;
    public float physicalDamage;
    public float fireDamage;
    public Collider damageCollider;
    public Rigidbody rb;
    // protected List<CharacterManager> charactersDamaged = new List<CharacterManager>();
    protected Vector3 contactPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"DAMAGE COLLIDER TRIGGERED {other.transform.root.name}");
        if (other.transform.root.TryGetComponent(out CharacterManager character))
        {
            if (!canDamage) return;

            ApplyDamageEffect(other, character);
        }
        
    }

    protected virtual void ApplyDamageEffect(Collider other, CharacterManager character)
    {
        contactPoint = other.ClosestPointOnBounds(transform.position);
        TakeDamageEffect takeDamageEffect = character.characterEffectManager.takeDamageEffect; //GET DAMAGE EFFECT
        takeDamageEffect.physicalDamage = physicalDamage;
        takeDamageEffect.contactPoint = contactPoint;

        takeDamageEffect.ProcessEffect(character);
    }
}
