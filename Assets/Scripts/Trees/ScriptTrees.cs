using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTrees : MonoBehaviour
{
    [SerializeField] GameObject[] logPrefabs;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            BallController player = collision.collider.gameObject.GetComponent<BallController>();

            if (player.moveTime == player.howLongToMoveToKillTree)
            {
                player.moveTime = 0;
                Instantiate(logPrefabs[Random.Range(0, logPrefabs.Length)], transform.position, transform.rotation);
                GameObject.Find("Trees").GetComponent<SpawnTrees>().treeCount--;
                Destroy(gameObject);
            }
        }
    }
}
