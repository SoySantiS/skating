using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    private void Start()
    {
        GameManager.SharedInstance.onGameFinished.AddListener(RegisterValues);
    }

    void RegisterScore()
    {
        var actualScore = PointsManager.SharedInstance.Amount;
        PlayerPrefs.SetInt("Last Score", actualScore);
    }
    
    void RegisterTime()
    {
        var actualMinutes = Timer.SharedInstance.Minutes;
        var actualSeconds = Timer.SharedInstance.Seconds;
        
        PlayerPrefs.SetInt("Last Minutes", actualMinutes);
        PlayerPrefs.SetInt("Last Seconds", actualSeconds);
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
