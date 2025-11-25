using System;
using DG.Tweening;
using UnityEngine;

public class CharacterEffectManager : MonoBehaviour
{
    [Header("VFX")]
    public GameObject bloodSplatterVFX;
    
    [Header("Effects")]
    public TakeDamageEffect takeDamageEffect;
    
    private MeshRenderer meshRenderer;
    private Color color;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        color = meshRenderer.material.color;
    }

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
    public void HitEffect()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(meshRenderer.material.DOColor(Color.white, 0.15f));
        sequence.Append(meshRenderer.material.DOColor(color, 0.1f));
    }
}