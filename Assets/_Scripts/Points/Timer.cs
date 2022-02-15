using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer SharedInstance;
    
    [Header("Timer")]
    [SerializeField] private float timerCount;
    [SerializeField] private int iTimer;

    [SerializeField] private TMP_Text timerText;

    [Header("Timer Values")]
    [SerializeField] private int minutes;

    [SerializeField] private PlayerMovement playerMovement;
    public int Minutes
    {
        get => minutes;
    }

    [SerializeField] private int seconds;
    public int Seconds
    {
        get => seconds;
    }

    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if (playerMovement.gameFinished == false)
        {
            ChangeTimerValaue();
        }
        minutes = iTimer / 60;
        seconds = iTimer % 60;

        timerText.text = $"{minutes}:{seconds}";
    }

    void ChangeTimerValaue()
    {
        timerCount += Time.deltaTime;

        iTimer = (int) timerCount;
    }
}
