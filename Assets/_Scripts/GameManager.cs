using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;
    
    //Eventos:
    public UnityEvent onGameFinished;

    private bool gameFinished;
    public bool GameFinished
    {
        get => gameFinished;
        set => gameFinished = value;
    }

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

        gameFinished = false;
    }

    void GameOver()
    {
        gameFinished = true;
    }
}
