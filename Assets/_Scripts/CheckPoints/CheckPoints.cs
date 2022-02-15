using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Add Points", menuName = "Points/New CheckPoint")]
public class CheckPoints : ScriptableObject
{
    [Header("Lvl")]
    [SerializeField] private int level;

    public int Level => level;
    
    [Header("When")]
    [SerializeField] private int minutes;
    public int Minutes
    {
        get => minutes;
    }

    [SerializeField] private int seconds;
    public int Seconds => seconds;
    
    [Header("How many")]
    [Tooltip("Cantidad de puntos al agregar cuando pasa x")]
    [SerializeField] private int points;
    public int Points => points;
}
