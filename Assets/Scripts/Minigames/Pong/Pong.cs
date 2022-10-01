using UnityEngine;

public class Pong : Minigame
{
    public Rigidbody2D ball;
    public int ballSpeed;

    [Header("Paddles")]
    public int paddleSpeed;
    public GameObject paddle1;
    public GameObject paddle2;
    public GameObject paddle3;
    public GameObject paddle4;

    [Header("Keybinds")]
    public KeyCode player1Left;
    public KeyCode player1Right;

    public KeyCode player2Left;
    public KeyCode player2Right;

    public KeyCode player3Up;
    public KeyCode player3Down;

    public KeyCode player4Up;
    public KeyCode player4Down;

    private void Controls()
    {
        if (Input.GetKey(player1Left))
            paddle1.transform.Translate(-paddleSpeed * Time.deltaTime, 0, 0);
        else if (Input.GetKey(player1Right))
            paddle1.transform.Translate(paddleSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKey(player2Left))
            paddle2.transform.Translate(-paddleSpeed * Time.deltaTime, 0, 0);
        else if (Input.GetKey(player2Right))
            paddle2.transform.Translate(paddleSpeed * Time.deltaTime, 0, 0);

        if (Input.GetKey(player3Up))
            paddle3.transform.Translate(0, paddleSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(player3Down))
            paddle3.transform.Translate(0, -paddleSpeed * Time.deltaTime, 0);

        if (Input.GetKey(player4Up))
            paddle4.transform.Translate(0, paddleSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(player4Down))
            paddle4.transform.Translate(0, -paddleSpeed * Time.deltaTime, 0);
    }
    private void Update()
    {
        Controls();
    }
}
