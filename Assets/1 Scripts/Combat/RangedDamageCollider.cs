using UnityEngine;

public class RangedDamageCollider : DamageCollider
{
    protected override void ApplyDamageEffect(Collider other, CharacterManager character)
    {
        base.ApplyDamageEffect(other, character);
        
        canDamage = false;
        rb.isKinematic = true;
    }
}