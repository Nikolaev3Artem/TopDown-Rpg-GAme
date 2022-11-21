using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxStamina(double stamina)
    {
        slider.maxValue = (float)stamina;
        slider.value = (float)stamina;
    }

    public void SetStamina(double stamina)
    {
        slider.value = (float)stamina;
    }
}
