using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamScript : MonoBehaviour
{
    [SerializeField] GameObject[] stages = new GameObject[5];
    public int logs = 0;
    int totalLogs = 0;
    [SerializeField] float startTime = 25f;
    [SerializeField] float floodSpeed = 17f;

    [SerializeField] AudioClip[] logPutInSFX;

    [Header("Playerprefs")]
    [SerializeField] Timer timer;

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
            Camera.main.GetComponent<AudioSource>().PlayOneShot(logPutInSFX[Random.Range(0, logPutInSFX.Length)]);
            logs++;
            totalLogs++;
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
        for(int i = 0; i < stages.Length; i++)
        {
            if (i < logs) stages[i].SetActive(true);
            else stages[i].SetActive(false);
        }
    }
    
    void GameOver() 
    {
        SceneManager.LoadScene("Flood");

        PlayerPrefs.SetFloat("WoodAmount", totalLogs);
        PlayerPrefs.SetFloat("Time", timer.time);

        if (totalLogs > PlayerPrefs.GetFloat("BestWoodAmount", 0)) PlayerPrefs.SetFloat("BestWoodAmount", totalLogs);
        if (timer.time > PlayerPrefs.GetFloat("BestTime", 0)) PlayerPrefs.SetFloat("BestTime", timer.time);

        PlayerPrefs.Save();
    }

    void Flood()
    {
        logs--;
        ShowDam();
    }
}
