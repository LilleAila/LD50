using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamScript : MonoBehaviour
{
    [SerializeField] GameObject[] stages = new GameObject[5];
    public int logs = 0;
    [SerializeField] float startTime = 25f;
    [SerializeField] float floodSpeed = 17f;

    private void Start()
    {
        ShowDam();
        InvokeRepeating("Flood", startTime, floodSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Log")
        {
            if (logs >= 20) return;
            logs++;
            ShowDam();
            Destroy(collision.gameObject);
        }
    }

    public void ShowDam()
    {
        if (logs < 0)
        {
            GameOver();
            return;
        }
        // int currentStage = Mathf.FloorToInt(logs / stages.Length);
        // for (int i = 0; i < stages.Length; i++) stages[i].SetActive(false);
        // stages[currentStage].SetActive(true);
        for(int i = 0; i < stages.Length; i++)
        {
            if (i < logs) stages[i].SetActive(true);
            else stages[i].SetActive(false);
        }
    }

    void GameOver() { }

    void Flood()
    {
        logs--;
        ShowDam();
    }
}
