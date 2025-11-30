using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;


public class PlayerEffectManager : CharacterEffectManager
{   
    [HideInInspector] public PlayerManager player;
    [Header("Volume")]
    public Volume playerVolume;
    [Header("Flash Effect")]
    float flashIntensity = 0.45f;   // how strong the flash is
    float duration = 0.15f;
    float fadeTime = 0.25f; // how long the flash lasts
    float defaultIntensity;
    private Vignette vignette;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<PlayerManager>();
        playerVolume.profile.TryGet(out vignette);
        defaultIntensity = vignette.intensity.value;
    }

    public override void GetDamageEffect()
    {
        Debug.Log($"GetDamageEffect");
        StartCoroutine(FlashEffect());
    }

    IEnumerator FlashEffect()
    {
        if (vignette == null)
            yield break;

        // Flash up
        vignette.intensity.value = flashIntensity;
        yield return new WaitForSeconds(duration);

        // Smoothly fade back
        float t = 0f;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            vignette.intensity.value = Mathf.Lerp(flashIntensity, defaultIntensity, t / fadeTime);
            yield return null;
        }

        vignette.intensity.value = defaultIntensity;
    }
}