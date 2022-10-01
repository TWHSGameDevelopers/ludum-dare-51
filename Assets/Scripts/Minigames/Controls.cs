using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public int playerNum = 0;//the player numbers are 0 through 3.
    public static string[] axisHoriz= {"Horizontal0", "Horizontal1", "Horizontal2", "Horizontal3" };//input axis in the build setting of the project
    public static string[] jump= { "Jump0", "Jump1", "Jump2", "Jump3" };//input jump buttons in the build setting of the project
    public static string[] atk = { "Atk0", "Atk1", "Atk2", "Atk3" };//input attack or interact buttons in the build setting of the project
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
        if (Input.GetAxis(jump[playerNum])!=0)
        {
            print("jump it: "+Input.GetAxis(jump[playerNum]));
            yForce += jumpSize;
        }
        Vector2 force = new Vector2(xForce, yForce);
        rb.AddForce(force);
        ClampVelocity(maxSpeed, maxSpeed);
        if (Input.GetAxis(atk[playerNum]) != 0)
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