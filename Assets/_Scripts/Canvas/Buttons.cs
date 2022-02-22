using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] private LoadLastLvl loadLastLvl;
    [SerializeField] private AudioSource selectSFX, restartSFX;

    [SerializeField] private AudioMixerSnapshot normalSnp, pauseSnp;

    public void PlayAgain()
    {
        Time.timeScale = 1;
        DontDestroyOnLoad(restartSFX);
        restartSFX.Play();
        var lastLevel = PlayerPrefs.GetInt("Level");
        PlayerPrefs.SetInt("Level", lastLevel);
        SceneManager.LoadScene($"Level{lastLevel}");
    }
    public void NextLevel()
    {
        LvlManager.SharedInstance.LoadNextLevel();
        selectSFX.Play();
    }
    
    public void LoadLastLevel()
    {
        loadLastLvl.LoadLastLevel();
        selectSFX.Play();
    }
    public void ToMenu()
    {
        Time.timeScale = 1;
        selectSFX.Play();
        SceneManager.LoadScene("MainMenu");
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        selectSFX.Play();
        
        pauseSnp.TransitionTo(0);
    }

    public void DesPauseGame()
    {
        Time.timeScale = 1;
        selectSFX.Play();
        
        normalSnp.TransitionTo(0.2f);
    }

    public void ClearData()
    {
        PlayerPrefs.SetInt("Level", 1);
        PlayerPrefs.SetInt("Last Game Finished",0);
    }
}
