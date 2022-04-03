using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelButton : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject dam;
    [SerializeField] GameObject woodAmount;
    [SerializeField] GameObject timer;
    [SerializeField] BallController player;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(StartButton);
    }

    void StartButton()
    {
        dam.SetActive(true);
        woodAmount.SetActive(true);
        timer.SetActive(true);
        player.enabled = true;

        Destroy(startPanel);
    }
}
