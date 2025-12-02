using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance;
    [Header("Screens")]
    public GameObject deathScreen;

    [Header("Elements")]
    public Image circleProgress;

    private void Awake()
    {
        Instance = this;
    }

    public void YouDied()
    {
        deathScreen.SetActive(true);
    }

    public void StartCircleProgress(float duration)
    {
        circleProgress.DOFade(1f, duration / 10);
        circleProgress.DOFillAmount(1f, duration);
    }
    public void StopCircleProgress()
    {
        circleProgress.DOKill();
        circleProgress.DOFade(0f, 0.1f);
        circleProgress.fillAmount = 0;
    }
}