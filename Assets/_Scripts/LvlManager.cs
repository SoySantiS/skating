using System;
using UnityEngine;

public class LvlManager : MonoBehaviour
{
    public static LvlManager SharedInstance;

    private int currentLvl = 1;
    public int CurrentLvl
    {
        get => currentLvl;
        set => currentLvl = value;
    }
    
    static int nextLvl = 1;
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
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
}