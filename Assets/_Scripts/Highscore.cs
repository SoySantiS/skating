using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    [SerializeField] private PointsManager pointsManager;
    [SerializeField] private Timer timer;
    
    [SerializeField] private SetTexts setTexts;

    private void Start()
    {
        GameManager.SharedInstance.onGameFinished.AddListener(RegisterValues);
    }

    public void RegisterScore()
    {
        var actualScore = pointsManager.Amount;
        PlayerPrefs.SetInt("Last Score", actualScore);

        var highScore = PlayerPrefs.GetInt("High Score", 10);
        if (actualScore > highScore)
        {
            PlayerPrefs.SetInt("High Score", actualScore);

            setTexts.bestScore = true;
            print(setTexts.bestScore);
        }
    }
    
    public void RegisterTime()
    {
        var actualMinutes = timer.Minutes;
        var actualSeconds = timer.Seconds;
        
        PlayerPrefs.SetInt("Last Minutes", actualMinutes);
        PlayerPrefs.SetInt("Last Seconds", actualSeconds);

        var lowMinutes = PlayerPrefs.GetInt("Lowest Minutes", 999999999);
        var lowSeconds = PlayerPrefs.GetInt("Lowest Seconds", 999999999);
        
        if (actualMinutes < lowMinutes)
        {
            if (actualSeconds < lowSeconds)
            {
                PlayerPrefs.SetInt("Lowest Minutes", actualMinutes);
                PlayerPrefs.SetInt("Lowest Seconds", actualSeconds);

                setTexts.lowestTime = true;
            }
        }
    }

    /// <summary>
    /// Es llamado al finalizar la partida, y registra los valores  (tiempo y puntaje)
    /// </summary>
    void RegisterValues()
    {
        RegisterScore();
        RegisterTime();
    }
}
