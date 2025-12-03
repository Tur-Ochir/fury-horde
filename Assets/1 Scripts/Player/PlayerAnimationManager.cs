using UnityEngine;


public class PlayerAnimationManager : CharacterAnimationManager
{
    [HideInInspector] public PlayerManager player;
    public Animator horseAnimator;

    protected override void Awake()
    {
        base.Awake();
        player = GetComponent<PlayerManager>();
    }

    protected override void Update()
    {
        base.Update();
        
        horseAnimator.SetFloat("Speed", player.playerMovement.GetSpeed());
    }

    public void PlayTargetAnimation(string target)
    {
        animator.Play(target);
    }
    
}