using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Ball")]
    public Rigidbody2D rb;
    public int speed;

    [Header("Camera")]
    public Camera cam;

    private void Launch()
    {
        int x = Random.Range(0, 2) == 0 ? speed : -speed;
        int y = Random.Range(0, 2) == 0 ? speed : -speed;
        rb.velocity = new Vector2(x, y);
    }
    private void Start()
    {
        Launch();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 upRight = new Vector2(speed, speed);
        Vector2 upLeft = new Vector2(-speed, speed);
        Vector2 downRight = new Vector2(speed, -speed);
        Vector2 downLeft = new Vector2(-speed, -speed);

        if (collision.CompareTag("LateralPaddle"))
        {
            if (rb.velocity == upRight)
                rb.velocity = downRight;
            else if (rb.velocity == upLeft)
                rb.velocity = downLeft;
            else if (rb.velocity == downRight)
                rb.velocity = upRight;
            else
                rb.velocity = upLeft;
        }
        else if (collision.CompareTag("VerticalPaddle"))
        {
            if (rb.velocity == upRight)
                rb.velocity = upLeft;
            else if (rb.velocity == upLeft)
                rb.velocity = upRight;
            else if (rb.velocity == downRight)
                rb.velocity = downLeft;
            else
                rb.velocity = downRight;
        }
    }
}
