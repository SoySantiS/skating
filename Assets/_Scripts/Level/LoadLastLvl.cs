using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLastLvl : MonoBehaviour
{
    public static LoadLastLvl SharedInstance;
    private int level;

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

    private void Start()
    {
        GameManager.SharedInstance.onGameFinished.AddListener(SaveLevelValue);
    }

    void SaveLevelValue()
    {
        PlayerPrefs.Save();
    }

    public void LoadLevel()
    {
        var nextLevel = PlayerPrefs.GetInt("Level");
        
        if (PlayerPrefs.GetInt("Last Game Finished") == 1)
        {
            nextLevel++;
            
            PlayerPrefs.SetInt("Last Game Finished", 0);
            
            PlayerPrefs.SetInt("Level", nextLevel);
            print($"Next Level: {PlayerPrefs.GetInt("Level")}");
            SceneManager.LoadScene($"Level{PlayerPrefs.GetInt("Level", nextLevel)}");
            print($"Last game finished: {PlayerPrefs.GetInt("Last Game Finished")}");
        }
        else
        {
            SceneManager.LoadScene($"Level{nextLevel}");
            print($"Last level: {nextLevel}");
        }
    }
}
