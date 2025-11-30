using System;
using UnityEngine;


public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    [Header("Screens")]
    public GameObject deathScreen;

    private void Awake()
    {
        Instance = this;
    }

    public void YouDied()
    {
        deathScreen.SetActive(true);
    }
}