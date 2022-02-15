using System;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public static PointsManager SharedInstance;
    
    //Referencias: 
    [SerializeField] private Highscore highscore;
    [SerializeField] private LoadLastLvl loadLastLvl;
    
    //Textos:
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private SetTexts setTexts;
    
    //Puntos:
    [SerializeField] private int amount;
    public int Amount
    {
        get => amount;
        set => amount = value;
    }
    public CheckPoints checkPoint;
    
    
    public bool alreadyFinishedCounting; // hay una variable que hace lo mismo en player movement ("game finished")
    private bool gameFinished; // hay una variable que hace lo mismo en player movement ("game finished").
    public bool GameFinished
    {
        get => gameFinished;
        set => gameFinished = value;
    }
    //TODO: en el gameManager, usar la variable de game finished


    /// <summary>
    /// Inicializo el singleton.
    /// </summary>
    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
            //DontDestroyOnLoad(this);
        }else
        {
            Destroy(this);
        }
        
        GameManager.SharedInstance.onGameFinished.AddListener(FinalCountOfPoints); //cuando termine la partida, llama al metodo FinalCountOfPoints
    }
    
    /// <summary>
    /// Método que se utiliza para agregar puntos
    /// </summary>
    /// <param name="numberOfPoints">Cantidad de puntos a sumar</param>
    public void AddPoints(int numberOfPoints)
    {
        amount += numberOfPoints;
        scoreText.text = $"Score: {amount.ToString()}";
    }
    
    /// <summary>
    /// Metodo que hace el conteo final de puntos (al terminar la partida)
    /// </summary>
    void FinalCountOfPoints()
    {
        gameFinished = true;
            
        Time.timeScale = 1;
            
        alreadyFinishedCounting = true;

        CheckExtraPoints();
    }

    /// <summary>
    /// Metodo que hace un chequeo de si hay que sumar puntos por terminar antes de x tiempo la partida
    /// </summary>
    void CheckExtraPoints()
    {
        if (Timer.SharedInstance.Minutes <= checkPoint.Minutes)
        {
            if (Timer.SharedInstance.Seconds <= checkPoint.Seconds)
            {
                var points = PlayerPrefs.GetInt("Last Score") + checkPoint.Points;
                PlayerPrefs.SetInt("Last Score", points);
            }
        } 
    }
}