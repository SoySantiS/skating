using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager SharedInstance;
    
    //Textos (script):
    [SerializeField] private SetTexts setTexts;
    
    //Puntos:
    [SerializeField] private int amount;
    public int Amount
    {
        get => amount;
    }
    
    public CheckPoints checkPoint;
    
    //Variables:
    public bool alreadyCounting;

    /// <summary>
    /// Inicializo el singleton.
    /// </summary>
    private void Awake()
    {
        if (SharedInstance == null)
        {
            SharedInstance = this;
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
        setTexts.ChamgeScoreText();
    }
    
    /// <summary>
    /// Metodo que hace el conteo final de puntos (al terminar la partida)
    /// </summary>
    void FinalCountOfPoints()
    {
        Time.timeScale = 1;
        alreadyCounting = true;    
        
        //chequeo de si hay que sumar puntos por terminar antes de x tiempo la partida:
        if (Timer.SharedInstance.Minutes <= checkPoint.Minutes)
        {
            if (Timer.SharedInstance.Seconds <= checkPoint.Seconds)
            {
                var points = PlayerPrefs.GetInt("Last Score") + checkPoint.Points;
                print(checkPoint.Points);
                PlayerPrefs.SetInt("Last Score", points);
            }
        }
    }
}