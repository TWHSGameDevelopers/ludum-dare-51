using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float minWait = 0.1f, maxWait = 0.8f;
    public Vector2 bound1, bound2;
    public GameObject coin;

    private void Start()
    {
        StartCoroutine(Drop());
    }

    IEnumerator Drop()
    {
        Instantiate(coin, DropPosition(), Quaternion.Euler(0, 0, 0), transform);
        yield return new WaitForSeconds(Random.value*(maxWait-minWait)+minWait);//0 to 1 inclusive both ways
        StartCoroutine(Drop());
        //recursion used to drop coins between 2 bounds at random repedetly
    }

    public Vector2 DropPosition()//randomly creates a position within 2 bounds
    {
        float x = Random.value*(bound2.x-bound1.x)+bound1.x;
        float y = Random.value * (bound2.y - bound1.y) + bound1.y;
        return new Vector2(x, y);
    }
}