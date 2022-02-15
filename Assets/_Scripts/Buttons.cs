using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private LoadLastLvl loadLastLvl;

    public void PlayAgain()
    {
        Time.timeScale = 1;
        //print(LvlManager.SharedInstance.CurrentLvl);
        SceneManager.LoadScene($"Level{LvlManager.SharedInstance.CurrentLvl}");
        
    }
    
    public void NextLevel()
    {
        Time.timeScale = 1;
        RefreshLvlValues();
        SceneManager.LoadScene($"Level{LvlManager.SharedInstance.NextLvl}");
        
    }
    void RefreshLvlValues()
    {
        if (GameManager.SharedInstance.GameFinished)
        {
            LvlManager.SharedInstance.CurrentLvl++;
            LvlManager.SharedInstance.NextLvl++;
        }
    }

    public void LoadLastLevel()
    {
        loadLastLvl.LoadLevel();
    }

    public void ToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void DesPauseGame()
    {
        Time.timeScale = 1;
    }
}
