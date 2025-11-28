using UnityEngine;

public class WeaponItem : ScriptableObject
{
    [Header("Weapon Base Damage")]
    public int baseDamage = 0;
    
    public virtual void AttemptToPerformAction(CharacterManager actionPerformer)
    {
        
    }
    public virtual void StartToPerformAction(CharacterManager actionPerformer)
    {
        
    }
}