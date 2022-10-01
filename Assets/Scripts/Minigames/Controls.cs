using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public int playerNum = 0;//the player numbers are 0 through 3.
    static string[] axisHoriz= {"Horizontal0", "Horizontal1", "Horizontal2", "Horizontal3" };//input axis in the build setting of the project
    static string[] jump= { "Jump0", "Jump1", "Jump2", "Jump3" };//input jump buttons in the build setting of the project
    static string[] atk = { "Atk0", "Atk1", "Atk2", "Atk3" };//input attack or interact buttons in the build setting of the project

    public bool canInput = true;//can enable or disable player movement
    public float speed = 10.0f;//the speed of horizontal movement
    public float maxSpeed= 100.0f;//the max speed x or y the player can experience
    public float jumpSize = 50;
    public int maxJumps = 1;
    public int jumpsUsed = 0;
    public float groundedDist = 0.5f;

    public Rigidbody2D rb;
    public GameObject floor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(canInput)
        {
            //print(Input.GetAxis(axisHoriz[playerNum]) + "||" + Input.GetAxis(jump[playerNum]) + "||"+Input.GetAxis(atk[playerNum]));
            float xForce = Input.GetAxis(axisHoriz[playerNum]) * speed;
            float yForce = 0;
            if ((Input.GetAxis(jump[playerNum]) != 0)&&(jumpsUsed<maxJumps))
            {
                //print("jump it: " + Input.GetAxis(jump[playerNum]));
                jumpsUsed++;
                yForce += jumpSize;
            }
            Vector2 force = new Vector2(xForce, yForce);
            rb.AddForce(force);//this force is the sum of the jump and horizontal inputs
            ClampVelocity(maxSpeed, maxSpeed);
            if (Input.GetAxis(atk[playerNum]) != 0)
            {
                Attack();
            }
        }
        if (Grounded())
        {
            jumpsUsed = 0;
        }
    }

    public bool Grounded()
    {
        if(transform.position.y-floor.transform.position.y<groundedDist)
        {
            return true;
        }
        return false;
    }

    public void Attack()
    {
        Debug.Log("attack mwahaha");
    }
    
    public Vector2 ClampVelocity(float x, float y)
    {
    	Vector2 nu =  new Vector2(Mathf.Clamp(rb.velocity.x, -1*maxSpeed, maxSpeed),Mathf.Clamp(rb.velocity.y, -1*maxSpeed, maxSpeed));
        rb.velocity = nu;
    	return rb.velocity;
    }

}