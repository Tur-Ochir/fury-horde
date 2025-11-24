using UnityEngine;

public class WeaponItem : ScriptableObject
{
    [Header("Weapon Base Damage")]
    public int baseDamage = 0;
    
    public virtual void AttemptToPerformAction(PlayerManager actionPerformer)
    {
        
    }
}