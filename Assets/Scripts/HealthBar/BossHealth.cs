using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHeath(int health)
    {
        healthSlider.value = 100;
    }

    public void SetHeath(int damage)
    {
        healthSlider.value -= damage;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
