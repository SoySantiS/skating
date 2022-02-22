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

    public void LoadLastLevel()
    {
        var nextLevel = PlayerPrefs.GetInt("Level");
        
        if (PlayerPrefs.GetInt("Last Game Finished") == 1)
        {
            level = PlayerPrefs.GetInt("Level");
            PlayerPrefs.SetInt("Level", level+1);
            SceneManager.LoadScene($"Level{PlayerPrefs.GetInt("Level",1)}");
            PlayerPrefs.SetInt("Last Game Finished", 0);
        }
        else
        {
            SceneManager.LoadScene($"Level{nextLevel}");
        }
    }
}
