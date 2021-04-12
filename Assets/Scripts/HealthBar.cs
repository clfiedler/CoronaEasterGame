using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //color gradient of the healthbar
    public Gradient gradient;
    
    public Image fill;

    public void Update()
    {
        //make healthbar green if health is full
        if (slider.normalizedValue == 5)
        {
            fill.color = gradient.Evaluate(1f);
        }
        
    }

    //set the healthbar to given number
    public void SetHealth(int health)
    {
        slider.value = health;
        
    }
    
    //substracts given number from healthbar
    public void LowerHealth(int remove)
    {
        slider.value -= remove;
        //change the color of the healthbar according to its value
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
