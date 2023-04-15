using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransformCharge : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxCharge(int chargeTime){
        slider.maxValue = chargeTime;
        slider.value = chargeTime;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetCharge(int chargeTime){
        slider.value = chargeTime;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
