using UnityEngine;

public class CharacterAnimationManager : MonoBehaviour
{
    [HideInInspector] public CharacterManager character;
    public Animator animator;
    
    protected virtual void Awake()
    {
        character = GetComponent<CharacterManager>();
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    
    public virtual void PlayerTargetAttackActionAnimation(string targetAnimation, bool isPerformingAction, bool applyRootMotion = true, bool canRotate = false, bool canMove = false)
    {
        character.isPerformingAction = isPerformingAction;
        animator.CrossFade(targetAnimation, 0.2f);
        // character.characterCombatManager.lastAttackAnimationPerformed = targetAnimation;
        // character.applyRootMotion = applyRootMotion;
        // character.canRotate = canRotate;
        // character.canMove = canMove;
    }
}