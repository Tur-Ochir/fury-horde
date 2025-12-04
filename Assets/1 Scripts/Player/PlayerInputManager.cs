using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    [HideInInspector] public PlayerManager player;
    private PlayerInput playerInput;
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction interactAction;
    private InputAction attackAction;
    private Vector2 moveInput;
    void Awake()
    {
        player = GetComponent<PlayerManager>();
        playerInput = GetComponent<PlayerInput>();
    }
    private void OnEnable()
    {
        playerInput.actions.Enable();
        
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        interactAction = playerInput.actions["Interact"];
        attackAction = playerInput.actions["Attack"];
    }
    private void OnDisable()
    {
        playerInput.actions.Disable();
    }
    
    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
        player.playerMovement.Move(moveInput);
        player.playerMovement.Rotate(moveInput);

        if (attackAction.WasPressedThisFrame())
        {
            player.playerCombat.StartWeaponBasedAction();
        }

        if (attackAction.WasReleasedThisFrame())
        {
            player.playerCombat.PerformWeaponBasedAction();
        }
    }
}
