using UnityEngine;


public class PlayerAnimationManager : CharacterAnimationManager
{
    [HideInInspector] public PlayerManager player;

    public void PlayTargetAnimation(string target)
    {
        animator.Play(target);
    }
    
}