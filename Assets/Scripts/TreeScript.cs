using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    [SerializeField] GameObject[] logPrefabs;
    [SerializeField] AudioClip[] logDieSFX;

    // Unity requires update for some reason
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            BallController player = collision.collider.gameObject.GetComponent<BallController>();

            if (player.moveTime == player.howLongToMoveToKillTree)
            {
                player.moveTime = 0;
                Instantiate(logPrefabs[Random.Range(0, logPrefabs.Length)], transform.position, transform.rotation);
                Camera.main.GetComponent<AudioSource>().PlayOneShot(logDieSFX[Random.Range(0, logDieSFX.Length)]);
                Destroy(gameObject);
            }
        }
    }
}
