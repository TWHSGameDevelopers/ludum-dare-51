using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flutter : MonoBehaviour
{
    public float minWait = 0.1f, maxWait = 0.5f;
    public Vector2 f1, f2;//the 2 forces the random force can be between
    //f1 should be down and left f2 should be right and up
    public Rigidbody2D rb;
    public bool shouldFlutter = true;

    private void Start()
    {
        if(shouldFlutter)
        {
            rb = GetComponent<Rigidbody2D>();
            StartCoroutine(RandomForce());
        }
    }

    IEnumerator RandomForce()
    {
        Vector2 randForce = new Vector2(0, 0);
        randForce.x += Random.value * (f2.x - f1.x) + f1.x;
        randForce.y += Random.value * (f2.y - f1.y) + f1.y;
        yield return new WaitForSeconds(Random.value * (maxWait - minWait) + minWait);//0 to 1 inclusive both ways
        StartCoroutine(RandomForce());
        //recursion used to add lots of random motion
    }
}
