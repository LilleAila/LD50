using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanelButton : MonoBehaviour
{
    [SerializeField] GameObject startPanel;

    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(StartButton);
    }

    void StartButton()
    {
        Destroy(startPanel);
    }
}
