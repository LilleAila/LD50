using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3;
    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        if(Mathf.Abs(horizontalInput) == Mathf.Abs(verticalInput))
        {
            rb.velocity = Vector2.zero;
            anim.enabled = false;
        } else
        {
            rb.AddForce(new Vector2(horizontalInput * movementSpeed, 0), ForceMode2D.Impulse);
            rb.AddForce(new Vector2(0, verticalInput * movementSpeed), ForceMode2D.Impulse);

            anim.enabled = true;

            if (horizontalInput != 0) anim.Play(horizontalInput == 1 ? "Player_Right" : "Player_Left");
            else anim.Play(verticalInput == 1 ? "Player_Up" : "Player_Down");
        }
    }
}
