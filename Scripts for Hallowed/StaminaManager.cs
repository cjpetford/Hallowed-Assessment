using UnityEngine;
using UnityEngine.UI;

public class StaminaManager : MonoBehaviour
{
    public Slider staminaSlider; // Reference to the stamina slider
    public float maxStamina = 100f; // Maximum stamina value

    // Update the stamina slider value based on the current stamina value
    public void UpdateStamina(float currentStamina)
    {
        // Ensure stamina slider reference is not null
        if (staminaSlider != null)
        {
            // Normalize the current stamina value between 0 and 1
            float normalizedStamina = Mathf.Clamp01(currentStamina / maxStamina);
            // Set the value of the stamina slider
            staminaSlider.value = normalizedStamina;
        }
    }
}
