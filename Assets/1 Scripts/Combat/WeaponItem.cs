using UnityEngine;

public class WeaponItem : ScriptableObject
{
    [Header("Weapon Damage")]
    public int physicalDamage = 0;
    public int fireDamage = 0;
    
    public virtual void AttemptToPerformAction(CharacterManager actionPerformer)
    {
        
    }
    public virtual void StartToPerformAction(CharacterManager actionPerformer)
    {
        
    }
}