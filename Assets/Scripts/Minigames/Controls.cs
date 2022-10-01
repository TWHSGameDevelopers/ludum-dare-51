using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public int playerNum = 0;//the player numbers are 0 through 3.
    public static string[] axisHoriz;//input axis in the build setting of the project
    public static KeyCode[] jump;//input jump buttons in the build setting of the project
    public static KeyCode[] atk;//input attack or interact buttons in the build setting of the project
    public float speed = 10.0f;//the speed of horizontal movement
    public float maxSpeed= 100.0f;//the max speed x or y the player can experience
    public float jumpSize = 10.0f;
    public static Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void update()
    {
        float xForce = Input.GetAxis(axisHoriz[playerNum]) * speed;
        float yForce = 0;
        if (Input.GetKey(jump[playerNum]))
        {
            yForce += jumpSize;
        }
        Vector2 force = new Vector2(xForce, yForce);
        rb.AddForce(force);
        ClampVelocity(maxSpeed, maxSpeed);
        if (Input.GetKey(atk[playerNum]))
        {
            Attack();
        }
    }

    public void Attack()
    {
        Debug.Log("attack mwahaha");
    }
    
    public Vector2 ClampVelocity(float x, float y)
    {
    	Vector2 nu =  new Vector2(Mathf.Clamp(GetComponent<Rigidbody>().velocity.x, -1*maxSpeed, maxSpeed),Mathf.Clamp(GetComponent<Rigidbody>().velocity.y, -1*maxSpeed, maxSpeed));
        rb.velocity = nu;
    	return rb.velocity;
    }

}