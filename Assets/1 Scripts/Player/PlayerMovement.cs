using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public PlayerManager player;
    public float speed = 4;
    public float rotationSpeed = 8;
    public bool autoMoveForward;
    
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    void Awake()
    {
        player = GetComponent<PlayerManager>();
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // RotateToCameraDirection();
        if (autoMoveForward)
        {
            controller.SimpleMove(transform.forward * speed);
        }
    }

    public void Move(Vector2 moveInput)
    {
        if (!player.canMove) return;
        if (moveInput.magnitude <= 0.01f) return;
        if (autoMoveForward) return;
        
        moveInput.Normalize();
        moveDirection = moveInput.y * transform.forward;
        moveDirection.Normalize();
        controller.SimpleMove(moveDirection * speed);
    }

    public void Rotate(Vector2 moveInput)
    {
        // Only rotate if x axis has input
        if (Mathf.Abs(moveInput.x) > 0.01f)
        {
            float turnAmount = moveInput.x * rotationSpeed * Time.deltaTime;

            // Rotate around Y
            // Debug.Log($"turnAmountL: {turnAmount}");
            transform.Rotate(0f, turnAmount, 0f);   
        }
    }
    public void RotateToCameraDirection()
    {
        if (!player.canRotate) return;
        
        Vector3 cameraForward = player.camTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();
    
        Rotate(cameraForward);
    }

    public float GetSpeed()
    {
        return controller.velocity.magnitude;
    }
}
