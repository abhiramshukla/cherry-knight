using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetInitialValue()
    {
        slider.value = slider.maxValue;
    }

    public void SetSliderValue(int value)
    {
        if (value >= slider.maxValue)
        {
            slider.maxValue = value;
            slider.value = slider.maxValue;
        }
        else
        {
            slider.value = value;
        }
    }

    public int GetSliderValue()
    {
        int val = (int)slider.value;
        return val;
    }

    public void IncreaseSliderValue(int value)
    {
        if (value >= slider.maxValue)
        {
            slider.value = slider.maxValue;
        }
        else if (value <= 0)
        {
            return;
        }
        else
        {
            slider.value += value;
        }
    }

    public void DecreaseSliderValue(int value)
    {
        if (value >= slider.maxValue)
        {
            slider.value = 1;
        }
        else if (value <= 0)
        {
            return;
        }
        else
        {
            slider.value -= value;
        }
    }
}
