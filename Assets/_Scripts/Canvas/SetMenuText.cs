using System;
using TMPro;
using UnityEngine;

public class SetMenuText : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Last Game Finished") == 1)
        {
            levelText.text = $"Next: Level {PlayerPrefs.GetInt("Level", 1) + 1}";
        }
        else
        {
            levelText.text = $"Next: Level {PlayerPrefs.GetInt("Level", 1)}";
        }
    }
}
