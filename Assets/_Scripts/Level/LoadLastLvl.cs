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
        var lastLevel = PlayerPrefs.GetInt("Level");
        
        if (PlayerPrefs.GetInt("Last Game Finished") == 1)
        {
            SceneManager.LoadScene($"Level{lastLevel + 1}");
            print(PlayerPrefs.GetInt("Last Game Finished"));
            PlayerPrefs.SetInt("Last Game Finished", 0);
            LvlManager.SharedInstance.NextLvl++;
            PlayerPrefs.SetInt("Level", LvlManager.SharedInstance.NextLvl);
        }
        else
        {
            SceneManager.LoadScene($"Level{lastLevel}");
        }
    }
}
