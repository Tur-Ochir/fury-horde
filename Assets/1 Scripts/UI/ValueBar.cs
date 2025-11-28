using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ValueBar : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI valueText;
    public void UpdateValueBar(float currentValue, float maxValue)
    {
        if (maxValue <= 0)
        {
            image.fillAmount = 0;
        }
        else
        {
            image.fillAmount = currentValue / maxValue;

            if (valueText != null)
            {
                valueText.text = $"{(int)currentValue}";
            }
        }
    }
}