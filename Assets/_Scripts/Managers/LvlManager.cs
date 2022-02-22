using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlManager : MonoBehaviour
{
    public static LvlManager SharedInstance;

    private int currentLvl = 1;
    public int CurrentLvl
    {
        get => currentLvl;
        set => currentLvl = value;
    }
    
    static int nextLvl;
    public int NextLvl
    {
        get => nextLvl;
        set => nextLvl = value;
    }

    [SerializeField] private int levels;

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
            nextLvl = 1;
            PlayerPrefs.SetInt("Level", nextLvl);
        }
        else
        {
            nextLvl = PlayerPrefs.GetInt("Level", 1);
        }
    }

    /// <summary>
    /// Método para cargar el siguiente nivel
    /// </summary>
    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Level", nextLvl);
        
        var lastLevel = PlayerPrefs.GetInt("Level") + 1;
        
        SceneManager.LoadScene($"Level{lastLevel}");
        PlayerPrefs.SetInt("Level", lastLevel);
    }
}