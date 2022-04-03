using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3;
    [SerializeField] public float howLongToMoveToKillTree;
    Rigidbody2D rb;
    Animator anim;
    float horizontalInput;
    float verticalInput;

    [HideInInspector] public float moveTime;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        
        if(Mathf.Abs(horizontalInput) == Mathf.Abs(verticalInput))
        {
            rb.velocity = Vector2.zero;
            anim.enabled = false;
        } else
        {
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            rb.AddForce(movement * movementSpeed, ForceMode2D.Impulse);

            anim.enabled = true;

            if (horizontalInput != 0) anim.Play(horizontalInput == 1 ? "Player_Right" : "Player_Left");
            else anim.Play(verticalInput == 1 ? "Player_Up" : "Player_Down");
        }
    }

    // Update fordi timer skal vere basert på lag fordi ellers spill bli vanskelig
    private void Update()
    {
        if (horizontalInput != 0 || verticalInput != 0)
        {
            if (moveTime >= howLongToMoveToKillTree)
            {
                moveTime = howLongToMoveToKillTree;
            }
            else
            {
                moveTime += Time.deltaTime;
            }
        }
        else
        {
            moveTime = 0;
        }
    }
}
