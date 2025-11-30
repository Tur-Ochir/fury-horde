using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/Melee Weapon", order = 0)]
public class MeleeWeapon : WeaponItem
{
    public string attack01 = "Main_Attack_01";
    public string attack02 = "Main_Attack_02";
    public string attack03 = "Main_Attack_03";
    [Header("RangedSFX")]
    public AudioClip[] attackSounds;
    public override void AttemptToPerformAction(CharacterManager actionPerformer)
    {
        if (actionPerformer.isPerformingAction) return;

        PerformAttack(actionPerformer);
        // PlaySFX(actionPerformer);
    }

    private void PerformAttack(CharacterManager actionPerformer)
    {
        actionPerformer.characterAnimationManager.PlayTargetAttackActionAnimation(attack01, true);
    }

    private void PlaySFX(CharacterManager actionPerformer)
    {
        actionPerformer.characterEffectManager.PlaySFX(attackSounds[Random.Range(0, attackSounds.Length)]);
    }

    public override void StartToPerformAction(CharacterManager actionPerformer)
    {
       
    }
}