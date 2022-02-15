using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLastLvl : MonoBehaviour
{
    private int level;

    private void Start()
    {
        GameManager.SharedInstance.onGameFinished.AddListener(SaveLevelValue);
    }

    public void SaveLevelValue()
    {
        level = LvlManager.SharedInstance.CurrentLvl;
        
        PlayerPrefs.SetInt("Level", level);
    }

    public void LoadLevel()
    {
        var lastLevel = PlayerPrefs.GetInt("Level", 1);
        if (PointsManager.SharedInstance.GameFinished)
        {
            lastLevel++;
            print(lastLevel);
            SceneManager.LoadScene($"Level{lastLevel}");
            //RefreshLvlValues();
        }
        else
        {
            SceneManager.LoadScene($"Level{lastLevel}");
            //RefreshLvlValues();
        }
    }
    
    void RefreshLvlValues()
    {
        LvlManager.SharedInstance.CurrentLvl++;
        LvlManager.SharedInstance.NextLvl++;
    }
}
