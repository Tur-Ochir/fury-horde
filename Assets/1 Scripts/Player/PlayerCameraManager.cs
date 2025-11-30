using System;
using UnityEngine;

public class PlayerCameraManager : MonoBehaviour
{
    [HideInInspector] public PlayerManager player;

    private void Awake()
    {
        player = GetComponent<PlayerManager>();
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        player.OnDeath += ShowCursor;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
