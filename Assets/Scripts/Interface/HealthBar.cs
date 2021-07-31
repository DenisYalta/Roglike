using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider HealthSlider;
    public Text HealthAmmountText;


    public void SetMaxHealth(float HeroMaxHealth)
    {
        HealthSlider.maxValue = HeroMaxHealth;
        HealthSlider.value = HeroMaxHealth;
        HealthAmmountText.text = HeroMaxHealth.ToString() + "/" + HeroMaxHealth.ToString();

    }

    public void SetHealthBar(float HeroCurrentHealth, float HeroMaxHealth)
    {

        HealthSlider.value = HeroCurrentHealth;
        HealthAmmountText.text = HeroCurrentHealth.ToString() + "/" + HeroMaxHealth.ToString();
    }

}
