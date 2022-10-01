using UnityEngine;

public class Pong : Minigame
{
    public int[] scores = new int[4];

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
    private void ClampX(Transform paddle, float min, float max)
    {
        float x = paddle.position.x;
        float y = paddle.position.y;

        paddle.position = new Vector2(Mathf.Clamp(x, min, max), y);
    }
    private void ClampY(Transform paddle, float min, float max)
    {
        float x = paddle.position.x;
        float y = paddle.position.y;

        paddle.position = new Vector2(x, Mathf.Clamp(y, min, max));
    }
    private void Update()
    {
        Controls();

        ClampX(paddle1.transform, -6.4f, 6.4f);
        ClampX(paddle2.transform, -6.4f, 6.4f);
        ClampY(paddle3.transform, -3.2f, 3.2f);
        ClampY(paddle4.transform, -3.2f, 3.2f);
    }
    public void Score(int playerIndex, int amount)
    {
        int prev = scores[playerIndex];
        int next = prev + amount;

        if (next < 1) next = 0;

        scores[playerIndex] = next;
    }
}
