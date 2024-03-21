using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> levels;
    
    public RectTransform experienceValueRectTransform;
    public TextMeshProUGUI levelValueTMP;
    
    private int _levelValue = 1;

    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    private void Start()
    {
        SetLevel(_levelValue);
        DrowUI();
    }
    
    public void AddExperience(float value)
    {
        _experienceCurrentValue += value; 
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            SetLevel(_levelValue + 1);
           _experienceCurrentValue = 0;  
        }
        DrowUI();
    }
    private void SetLevel(int value)
    {
        _levelValue = value;

        var currentLevel =  levels[_levelValue - 1];
        _experienceTargetValue = currentLevel.experienceForTheNextLevel;
        GetComponent<FireballCaster>().damage = currentLevel.fireballDamage;
        
        var grenadeCaster = GetComponent<GrenadeCaster>();
        grenadeCaster.damage = currentLevel.grenadeDamage; 

        if (currentLevel.grenadeDamage < 0)
            grenadeCaster.enabled = false;
        else 
            grenadeCaster.enabled = true;
    }
    
    private void DrowUI()
    {
        experienceValueRectTransform.anchorMax = new Vector2(_experienceCurrentValue / _experienceTargetValue, 1);
        levelValueTMP.text = _levelValue.ToString();
    }


}