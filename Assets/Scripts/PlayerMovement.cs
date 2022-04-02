using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0;
    private Animator plrAnimator;
    private Rigidbody2D plrRb;
    
    void Start()
    {
        plrRb = GetComponent<Rigidbody2D>();
        plrAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Making so only when not y then i can move x
        if (plrRb.velocity.y < 1 && plrRb.velocity.y  > -1)
        {
            plrRb.AddForce(new Vector2(horizontalInput * speed * Time.deltaTime, 0), ForceMode2D.Impulse);

            // Animation
            plrAnimator.SetFloat("LeftSpeed", Mathf.Abs(horizontalInput));
            plrAnimator.SetFloat("HorizontalSpeed", -horizontalInput);
        }
        // Making so only when not x then i can move y
        if (plrRb.velocity.x < 1 && plrRb.velocity.x > -1)
        {
            plrRb.AddForce(new Vector2(0, verticalInput * speed * Time.deltaTime), ForceMode2D.Impulse);

            // Animation
            plrAnimator.SetFloat("UpSpeed", Mathf.Abs(verticalInput));
            plrAnimator.SetFloat("VerticalSpeed", verticalInput);
        }
    }
}
