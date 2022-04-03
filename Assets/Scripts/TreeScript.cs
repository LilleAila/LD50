using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeScript : MonoBehaviour
{
    [SerializeField] LogScript logPrefab;

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
                Instantiate(logPrefab, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
