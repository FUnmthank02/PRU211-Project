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
        SetHeath(health);
    }

    public void SetHeath(int health)
    {
        healthSlider.value = health;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
