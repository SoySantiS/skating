using System;
using TMPro;
using UnityEngine;

public class SetMenuText : MonoBehaviour
{
    [SerializeField] private TMP_Text levelText;

    private void Start()
    {
        levelText.text = $"Next: Level {LvlManager.SharedInstance.NextLvl+1}";
    }
}
