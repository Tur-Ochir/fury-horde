using UnityEngine;

public class PlayerManager : CharacterManager
{
    [HideInInspector] public PlayerInputManager playerInput;
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public PlayerCombatManager playerCombat;
    protected virtual void Awake()
    {
        base.Awake();
        playerInput = GetComponent<PlayerInputManager>();
        playerMovement = GetComponent<PlayerMovement>();
        playerCombat = GetComponent<PlayerCombatManager>();
        
        camTransform = Camera.main.transform;
    }
}
