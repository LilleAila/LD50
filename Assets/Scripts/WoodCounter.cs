using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodCounter : MonoBehaviour
{
    [SerializeField] GameObject uiCounter;
    [SerializeField] GameObject worldCounter;
    [SerializeField] DamScript dam;

    void Update()
    {
        uiCounter.GetComponentInChildren<Text>().text = "" + dam.logs;
        worldCounter.GetComponentInChildren<Text>().text = "" + dam.logs;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiCounter.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            uiCounter.SetActive(true);
        }
    }
}
