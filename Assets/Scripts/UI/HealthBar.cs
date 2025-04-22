using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image fillImage;  
    [SerializeField] private HealthDamage health;  

    void Update()
    {
        if (health != null && fillImage != null)
        {
            float fillAmount = health.GetHealthPercent(); 
            fillImage.fillAmount = fillAmount;  
        }
    }
}
