using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SmoothSliderHealthDisplay : HealthDisplay
{
    [SerializeField] private Slider _slider;

    protected override void OnHealthChange(int value)
    {
        if( value < 0 )
            value = 0;

        float duration = 1;
        _slider.maxValue = Health.MaxHealth;
        _slider.DOValue(value, duration, false);
    }
}
