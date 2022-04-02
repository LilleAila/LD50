using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float xJump = 17.75f;
    [SerializeField] private float xTrigger = 9f;
    [SerializeField] private float yJump = 10f;
    [SerializeField] private float yTrigger = 5.5f;

    void Update()
    {
        // X Axis
        if (player.transform.position.x > (transform.position.x + xTrigger))
        {
            transform.localPosition = new Vector3(transform.localPosition.x + xJump, transform.localPosition.y, transform.localPosition.z);
        }
        else if (player.transform.position.x < (transform.position.x - xTrigger))
        {
            transform.localPosition = new Vector3(transform.localPosition.x - xJump, transform.localPosition.y, transform.localPosition.z);
        }

        // Y Axis
        if (player.transform.position.y > (transform.position.y + yTrigger))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + yJump, transform.localPosition.z);
        }
        else if (player.transform.position.y < (transform.position.y - yTrigger))
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - yJump, transform.localPosition.z);
        }
    }
}
