
using System;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    
    //Eventos:
    public UnityEvent onGameFinished;

    [SerializeField] private AudioSource finalCoutSFX;
    
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
        
        //llamo a la función de GameOver()
        onGameFinished.AddListener(GameOver);
    }

    void GameOver()
    {
        DontDestroyOnLoad(finalCoutSFX);
        finalCoutSFX.Play();
        PlayerPrefs.SetInt("Last Game Finished", 1);
    }
}
