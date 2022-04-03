using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamScript : MonoBehaviour
{
    [SerializeField] GameObject[] stages = new GameObject[5];
    public int logs = 0;

    private void Start()
    {
        ShowDam();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Log")
        {
            logs++;
            ShowDam();
            Destroy(collision.gameObject);
        }
    }

    public void ShowDam()
    {
        int currentStage = Mathf.FloorToInt(logs / stages.Length);
        for (int i = 0; i < stages.Length; i++) stages[i].SetActive(false);
        stages[currentStage].SetActive(true);
    }
}
