using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public int playerNum = 0;//the player numbers are 0 through 3.
    static string[] axisHoriz= {"Horizontal0", "Horizontal1", "Horizontal2", "Horizontal3" };//input axis in the build setting of the project
    static string[] jump= { "Jump0", "Jump1", "Jump2", "Jump3" };//input jump buttons in the build setting of the project
    static string[] atk = { "Atk0", "Atk1", "Atk2", "Atk3" };//input attack or interact buttons in the build setting of the project

    public Vector2 startPos;
    public bool canInput = true;//can enable or disable player movement
    public float speed = 10.0f;//the speed of horizontal movement
    public float maxSpeed= 100.0f;//the max speed x or y the player can experience
    public bool faceRight = true;

    public bool canJump = true;
    public float jumpSize = 50;
    public int maxJumps = 1;
    public int jumpsUsed = 0;
    public float jumpLag = 0.3f;//coooldoown before one can jump again
    public float groundedDist = 0.5f;

    public float friction = 0.1f; // 0.1 means lose 0.1 of momentum

    public Rigidbody2D rb;
    public GameObject floor;
    public Hit hitScript;
    public Animator anim;

    private void Awake()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        if(canInput)
        {
            print(playerNum+" jump it: " + Input.GetAxis(jump[playerNum]));
            //print(Input.GetAxis(axisHoriz[playerNum]) + "||" + Input.GetAxis(jump[playerNum]) + "||"+Input.GetAxis(atk[playerNum]));
            if(Input.GetAxis(axisHoriz[playerNum])>0.1f)
            {
                if (!faceRight)
                {
                    faceRight = true;
                    transform.localScale = new Vector2(1,1);
                }
            }
            else if(Input.GetAxis(axisHoriz[playerNum]) < -0.1f)
            {
                if (faceRight)
                {
                    faceRight = false;
                    transform.localScale = new Vector2(-1, 1);
                }
            }
            float xForce = Input.GetAxis(axisHoriz[playerNum]) * speed;
            float yForce = 0;
            if ((Input.GetAxis(jump[playerNum]) > 0.1f) && (jumpsUsed < maxJumps) && canJump)
            {
                //print("jump used");
                StartCoroutine(JumpLag());
                //print("jump it: " + Input.GetAxis(jump[playerNum]));
                print("went past");
                jumpsUsed++;
                yForce += jumpSize;
                rb.velocity = new Vector2(rb.velocity.x, 0);//resets vertical momentum
                //print("yforce: " + yForce);
            }
            Vector2 force = new Vector2(xForce, yForce);
            rb.AddForce(force);//this force is the sum of the jump and horizontal input
            //print(force + " added");
            if (Input.GetAxis(atk[playerNum]) != 0)
            {
                Attack();
            }
        }
        if (Grounded())
        {
            Friction();
            jumpsUsed = 0;
        }
        ClampVelocity(maxSpeed, maxSpeed);
    }

    public void Friction()
    {
        rb.velocity *= (1.0f-friction);
    }

    public bool Grounded()
    {/*
        if(transform.position.y-floor.transform.position.y<groundedDist)
        {
            return true;
        }
        return false;
    */
        if (Physics2D.Raycast(transform.position, Vector2.down, groundedDist, 64))//64 binary for 6 layermask
        {
            return true;
        }
        return false;
    }

    public void Attack()
    {
        //Debug.Log("attack mwahaha");
        anim.SetTrigger("attack");
    }
    
    public Vector2 ClampVelocity(float x, float y)
    {
        //Vector2 nu = new Vector2(Mathf.Clamp(rb.velocity.x, -1 * maxSpeed, maxSpeed), Mathf.Clamp(rb.velocity.y, -1 * maxSpeed, maxSpeed));

        Vector2 nu =  new Vector2(Mathf.Clamp(rb.velocity.x, -1*maxSpeed, maxSpeed),rb.velocity.y);
        rb.velocity = nu;
    	return rb.velocity;
    }

    IEnumerator JumpLag()
    {
        canJump = false;
        yield return new WaitForSeconds(jumpLag);
        canJump = true;
    }
}