using UnityEngine;

public class CharacterEffectManager : MonoBehaviour
{
    [Header("VFX")]
    public GameObject bloodSplatterVFX;
    
    [Header("Effects")]
    public TakeDamageEffect takeDamageEffect;
    public void PlayBloodSplatterVFX(Vector3 contactPoint)
    {
        if (bloodSplatterVFX != null)
        {
            GameObject bloodSplatter = Instantiate(bloodSplatterVFX, contactPoint, Quaternion.identity);
        }
        else
        {
            GameObject bloodSplatter = Instantiate(WorldCharacterEffectManager.Instance.BloodSplatterVFX, contactPoint, Quaternion.identity);
        }
    }
}