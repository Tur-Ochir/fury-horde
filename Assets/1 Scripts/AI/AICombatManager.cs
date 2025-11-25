using UnityEngine;


public class AICombatManager : MonoBehaviour
{
    public WeaponItem currentWeaponItem;
    
    public void PerformWeaponBasedAction()
    {
        if (currentWeaponItem == null) return;
        
        // currentWeaponItem.AttemptToPerformAction(player);
    }
}