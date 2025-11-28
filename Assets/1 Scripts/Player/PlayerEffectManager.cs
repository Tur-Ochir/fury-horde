using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;


public class PlayerEffectManager : CharacterEffectManager
{   
    [Header("Volume")]
    public Volume playerVolume;
    public override void GetDamageEffect()
    {
        playerVolume.profile.TryGet(out Vignette v);
        // v.intensity.Interp(v.intensity.value, 0.45f, 0.1f);
    }
}