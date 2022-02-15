using System;
using TMPro;
using UnityEngine;

public class SetTexts : MonoBehaviour
{
    [SerializeField] private TMP_Text actualScore, highScore, actualTime, bestTime, scoreText;

    public bool lowestTime, bestScore;
    public void LoadTextValues()
    {
        actualScore.text = $"Score: {PlayerPrefs.GetInt("Last Score")}";

        actualTime.text = $"{PlayerPrefs.GetInt("Last Minutes")}:{PlayerPrefs.GetInt("Last Seconds")}";
        
        if (bestScore)
        {
            highScore.gameObject.SetActive(true);
        }if (lowestTime)
        {
            bestTime.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        GameManager.SharedInstance.onGameFinished.AddListener(LoadTextValues);
    }

    public void ChamgeScoreText()
    {
        scoreText.text = $"Score: {PointsManager.SharedInstance.Amount.ToString()}";
    }
}
