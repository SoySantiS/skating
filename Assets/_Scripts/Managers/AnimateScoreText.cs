using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimateScoreText : MonoBehaviour
{
    public static AnimateScoreText SharedInstance;
    
    private float currentValue;
    
    int targetValue;
    [SerializeField] float increment = .5f;
    [SerializeField] TMP_Text actualScoreText;

    public bool calledCounter;

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }else
        {
            Destroy(this);
        }
    }

    private void FixedUpdate()
    {
        if (calledCounter)
        {
            RefreshCounter();
        }
    }


    public void RefreshCounter()
    {
        targetValue = PlayerPrefs.GetInt("Last Score");
        if (currentValue != targetValue)
        {
            
            if (currentValue < targetValue)
            {
                currentValue += increment;
                if (currentValue > targetValue)
                {
                    currentValue = targetValue;
                }
            }
            else
            {
                currentValue -= increment;
                if (currentValue < targetValue)
                {
                    currentValue = targetValue;
                }
            }
        }
        WriteCounter((int)currentValue);
    }

    private void WriteCounter(int intToString)
    {
        var score = intToString.ToString();
        actualScoreText.text = $"Score: {score}";
    }
}
