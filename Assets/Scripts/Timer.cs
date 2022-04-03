using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float time = 0; // seconds
    Text timerText;
    
    void Start()
    {
        timerText = GetComponent<Text>();
    }
    
    void Update()
    {
        time += Time.deltaTime;

        timerText.text = timeToBetterTime();
    }

    string timeToBetterTime()
    {
        float minutes = Mathf.Floor(time / 60);
        float seconds = time - minutes * 60;

        return "" + minutes + ":" + Mathf.FloorToInt(seconds);
    }
}
