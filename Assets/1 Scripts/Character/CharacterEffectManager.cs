using System;
using DG.Tweening;
using UnityEngine;

public class CharacterEffectManager : MonoBehaviour
{
    [HideInInspector] private CharacterManager character;
    [Header("VFX")]
    public GameObject bloodSplatterVFX;
    public GameObject deathVFX;
    [Header("SFX")]
    [HideInInspector] public AudioSource audioSource;
    public AudioClip getDamageSound;
    
    [Header("Effects")]
    public TakeDamageEffect takeDamageEffect;
    
    private SkinnedMeshRenderer meshRenderer;
    private Color color;

    private void Awake()
    {
        character = GetComponent<CharacterManager>();
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        audioSource = GetComponent<AudioSource>();
        
        color = meshRenderer.material.color;
    }

    private void OnEnable()
    {
        character.OnDeath += OnDeath;
    }

    private void OnDeath()
    {
        if (deathVFX   != null)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
        }
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
    public void PlaySFX(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}