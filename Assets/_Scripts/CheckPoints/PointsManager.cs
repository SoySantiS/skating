using System;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PointsManager : MonoBehaviour
{
    public static PointsManager SharedInstance;
    
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private SetTexts setTexts;

        [SerializeField] private int amount;
        public int Amount
        {
            get => amount;
            set => amount = value;
        }

        public CheckPoints checkPoint;

        public UnityEvent onGameFinished;

        [SerializeField] private Timer timer;

        public bool alreadyFinishedCounting;

        [SerializeField] private Animator animator;

        [SerializeField] private Highscore highscore;

        [SerializeField] private Canvas winCanvas, normalCanvas, joystickCanvas;

        [SerializeField] private LoadLastLvl loadLastLvl;
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
                //DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
            
            onGameFinished.AddListener(FinalCountOfPoints); //cuando termine la partida, llama al metodo FinalCountOfPoints
        }

        /// <summary>
        /// ESTO NO TIENE NADA QUE VER ACA 
        /// </summary>
        private void Start()
        {
            winCanvas.gameObject.SetActive(false);
            print(winCanvas.gameObject.name);
            normalCanvas.gameObject.SetActive(true);
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


        void PrintSomething()
        {
            print("hola");
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
            
            winCanvas.gameObject.SetActive(true);
            normalCanvas.gameObject.SetActive(false);
            joystickCanvas.gameObject.SetActive(false);
            
            highscore.RegisterScore();
            highscore.RegisterTime();

            CheckExtraPoints();

            setTexts.LoadTextValues();
            
            loadLastLvl.SaveLevelValue();
        }

        void CheckExtraPoints()
        {
            if (timer.Minutes <= checkPoint.Minutes)
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