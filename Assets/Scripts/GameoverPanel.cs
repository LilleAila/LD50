using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverPanel : MonoBehaviour
{
    [SerializeField] Text text;
    
    void Start()
    {
        float woodAmount = PlayerPrefs.GetFloat("WoodAmount", 404);
        float time = PlayerPrefs.GetFloat("Time", 404);

        float minutes = Mathf.Floor(time / 60);
        float seconds = time - minutes * 60;

        text.text = "You got a total of " + woodAmount + " wood \n and survived for " + minutes + " minutes and " + seconds + " seconds!";
    }


}
