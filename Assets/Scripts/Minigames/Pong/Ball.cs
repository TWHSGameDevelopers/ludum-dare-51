using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Pong pong;

    [Header("Ball")]
    public Rigidbody2D rb;
    public int speed;

    private void Launch()
    {
        int x = Random.Range(0, 2) == 0 ? speed : -speed;
        int y = Random.Range(0, 2) == 0 ? speed : -speed;
        rb.velocity = new Vector2(x, y);
    }
    private void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        Launch();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Equals("TopWall"))
            pong.Score(0, -1);
        else if (collision.name.Equals("BottomWall"))
            pong.Score(1, -1);
        else if (collision.name.Equals("LeftWall"))
            pong.Score(2, -1);
        else if (collision.name.Equals("RightWall"))
            pong.Score(3, -1);

        ResetBall();
    }
    private void Start()
    {
        Launch();
    }
}
