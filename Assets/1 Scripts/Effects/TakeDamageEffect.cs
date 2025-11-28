using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

[CreateAssetMenu(menuName = "Character Effects/Instant Effect/Take Damage Effect")]
public class TakeDamageEffect : InstantCharacterEffect
{
    [Header("Character Causing Damage")]
    public CharacterManager attackingCharacter;

    [Header("Damage")]
    public float physicalDamage;
    private int finalDamage;

    [Header("Animation")]
    public bool playDamageAnimation = true;
    public bool manuallySelectDamageAnimation = false;
    public string damageAnimation = "TakeDamage";

    [Header("Sound FX")]
    public bool playDamageSFX = true;
    public AudioClip damageSFX;

    [Header("Direction Damage Taken From")]
    public float angleHitFrom;
    public Vector3 contactPoint;
    public override void ProcessEffect(CharacterManager character)
    {
        base.ProcessEffect(character);

        if (character.isDead) return;

        CalculateDamage(character);
        //CHECK WHICH DIRECTIONAL DAMAGE CAME FROM
        //PLAY A DAMAGE ANIMATION
        //PLAY A SOUND FX
        PlayDamageVFX(character);
        character.characterEffectManager.GetDamageEffect();
    }

    private void CalculateDamage(CharacterManager character)
    {
        if (character == null) return;

        finalDamage = Mathf.RoundToInt(physicalDamage);

        if (finalDamage <= 0)
        {
            finalDamage = 1;
        }
        character.health.TakeDamage(finalDamage);
    }
    private void PlayDamageVFX(CharacterManager character)
    {
        character.characterEffectManager.PlayBloodSplatterVFX(contactPoint);
    }
}