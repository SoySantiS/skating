using System;
using TMPro;
using UnityEngine;

public class SetTexts : MonoBehaviour
{
    [SerializeField] private TMP_Text actualScore, actualTime,  scoreText, morePointsText;

    [SerializeField] private CheckPoints checkPoint;
    
    private void Start()
    {
        GameManager.SharedInstance.onGameFinished.AddListener(LoadTextValues);
    }

    private void LoadTextValues()
    {
        AnimateScoreText.SharedInstance.calledCounter = true;

        actualTime.text = $"{PlayerPrefs.GetInt("Last Minutes")}:{PlayerPrefs.GetInt("Last Seconds")}";

        CheckExtraPoints();
    }


    void CheckExtraPoints()
    {
        if (PointsManager.SharedInstance.extraPoints)
        {
            morePointsText.gameObject.SetActive(true);
            if (checkPoint.Minutes >= 1 )
            {
                morePointsText.text = $"+{checkPoint.Points} points because of finishing faster than {checkPoint.Minutes}:{checkPoint.Seconds}";
            }else if (checkPoint.Minutes == 0)
            {
                morePointsText.text = $"+{checkPoint.Points} points because of finishing faster than {checkPoint.Seconds} seconds";
            }
        }
        else
        {
            morePointsText.gameObject.SetActive(false);
        }
    }

    public void ChamgeScoreText()
    {
        scoreText.text = $"Score: {PointsManager.SharedInstance.Amount.ToString()}";
    }
}
