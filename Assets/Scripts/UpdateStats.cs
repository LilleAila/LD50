using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateStats : MonoBehaviour
{
    [SerializeField] Text bestText;
    [SerializeField] Text previousText;
    [SerializeField] Text highScoreText;

    void Start()
    {
        float bestWoodAmount = PlayerPrefs.GetFloat("BestWoodAmount", 0);
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0);

        float woodAmount = PlayerPrefs.GetFloat("WoodAmount", 0);
        float time = PlayerPrefs.GetFloat("Time", 0);

        float bestMinutes = Mathf.Floor(time / 60);
        float bestSeconds = time - bestMinutes * 60;

        float minutes = Mathf.Floor(time / 60);
        float seconds = time - minutes * 60;

        bestText.text = "Best wood amount: " + bestWoodAmount + "\nLongest survived: " + bestMinutes + " minutes and " + Mathf.FloorToInt(bestSeconds) + " seconds";
        previousText.text = "Total wood amount: " + woodAmount + "\nSurvived: " + minutes + " minutes and " + Mathf.FloorToInt(seconds) + " seconds";
        highScoreText.text = "High score: " + bestWoodAmount;
    }
}
