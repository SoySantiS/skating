using System;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public static PointsManager SharedInstance;
    
    //Referencias: 
    [SerializeField] private Timer timer;
    [SerializeField] private Animator animator; //hacerlo en el player movement
    [SerializeField] private Highscore highscore;
    [SerializeField] private LoadLastLvl loadLastLvl;
    
     //hacerlo en otro script
    
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

    //Eventos:
    public UnityEvent onGameFinished;
    
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
        
        onGameFinished.AddListener(FinalCountOfPoints); //cuando termine la partida, llama al metodo FinalCountOfPoints
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
            print("On final count of points");
            
            gameFinished = true;
            
            Time.timeScale = 1;
            
            alreadyFinishedCounting = true;
            
            animator.SetBool("Moving", false);
            
            highscore.RegisterScore();
            highscore.RegisterTime();

            CheckExtraPoints();

            setTexts.LoadTextValues();
            
            loadLastLvl.SaveLevelValue();
    }

    void CheckExtraPoints()
    {
        if (Timer.SharedInstance.Minutes <= checkPoint.Minutes)
        {
            //print($"menos de {checkPoint.Minutes} minuto(s)");
            if (timer.Seconds <= checkPoint.Seconds)
            {
                //print($"sumar {checkPoint.Points} puntos");

                var points = PlayerPrefs.GetInt("Last Score") + checkPoint.Points;
                PlayerPrefs.SetInt("Last Score", points);
                //print(PlayerPrefs.GetInt("Last Score"));
            }
        } 
    }
}