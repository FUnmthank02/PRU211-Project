using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoblinHealth : MonoBehaviour
{
    public GoblinControl goblin;
    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHeath(int health)
    {
        SetHeath(health);
    }

    public void SetHeath(int damage)
    {
        healthSlider.value -= damage;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
    }
}
