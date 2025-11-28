using System;
using UnityEngine;

public class WorldCharacterEffectManager : MonoBehaviour
{
    public static WorldCharacterEffectManager Instance;
    public GameObject BloodSplatterVFX;

    private void Awake()
    {
        Instance = this;
    }
}