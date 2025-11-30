using UnityEngine;

public class PlayerManager : CharacterManager
{
    [HideInInspector] public PlayerInputManager playerInput;
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public PlayerCombatManager playerCombat;
    [HideInInspector] public PlayerEffectManager playerEffect;
    [HideInInspector] public PlayerAnimationManager playerAnimation;
    protected override void Awake()
    {
        base.Awake();
        playerInput = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombatManager>();
        playerEffect = GetComponent<PlayerEffectManager>();
        playerAnimation = GetComponent<PlayerAnimationManager>();
        
        camTransform = Camera.main.transform;
    }

    protected override void OnEnable()
    {
        OnDeath += Die;
    }

    private void Die()
    {
        canMove = false;
        canRotate = false;
        
        CanvasManager.Instance.YouDied();
        
        
    }
}
