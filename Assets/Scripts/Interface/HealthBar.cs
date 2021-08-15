using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{

    public Slider HealthSlider;
    public Text HealthAmmountText;


    public void SetHealthBar(float HeroMaxHealth, float HeroCurrentHealth)
    {
        HealthSlider.maxValue = HeroMaxHealth;
        HealthSlider.value = HeroCurrentHealth;
        HealthAmmountText.text = HeroCurrentHealth.ToString() + "/" + HeroMaxHealth.ToString();
    }
}
