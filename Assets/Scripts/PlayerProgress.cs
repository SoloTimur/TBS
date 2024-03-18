using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;
    
    private int _levelValue = 1;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value; 
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
           _levelValue +=1;
           _experienceCurrentValue = 0;  
        }
        DrowUI();
    }
    private void Start()
    {
        DrowUI();
    }
    private void DrowUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }


}