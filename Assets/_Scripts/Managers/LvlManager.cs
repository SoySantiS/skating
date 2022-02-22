using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    public static LvlManager SharedInstance;
    
    static int level;

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
        if (PlayerPrefs.GetInt("Level") == 0)
        {
            PlayerPrefs.SetInt("Level", 1);
        }
        else
        {
            level = PlayerPrefs.GetInt("Level", 1);
        }
    }

    /// <summary>
    /// Método para cargar el siguiente nivel
    /// </summary>
    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Level", level);
        
        var lastLevel = PlayerPrefs.GetInt("Level") + 1;
        print($"Last level: {lastLevel}");
        
        SceneManager.LoadScene($"Level{lastLevel}");
        PlayerPrefs.SetInt("Level", lastLevel);
    }
}