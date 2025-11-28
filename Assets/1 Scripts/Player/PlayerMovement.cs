using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector] public PlayerManager player;
    public float speed = 4;
    public float rotationSpeed = 8;
    
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    void Awake()
    {
        player = GetComponent<PlayerManager>();
        controller = GetComponent<CharacterController>();
        
    }

    private void Update()
    {
        RotateToCameraDirection();
    }

    public void Move(Vector2 moveInput)
    {
        moveInput.Normalize();
        
        moveDirection = moveInput.x * player.camTransform.right + moveInput.y * player.camTransform.forward;
        moveDirection.Normalize();
        controller.SimpleMove(moveDirection * speed);
    }

    public void Rotate(Vector3 direction)
    {
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.fixedDeltaTime *rotationSpeed);
    }
    public void RotateToCameraDirection()
    {
        Vector3 cameraForward = player.camTransform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Rotate(cameraForward);
    }
}
