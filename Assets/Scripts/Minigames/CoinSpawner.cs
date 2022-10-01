using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public Vector2 bound1, bound2;
    public GameObject coin;
    IEnumerator Drop()
    {
        Instantiate(coin, DropPosition(), Quaternion.Euler(0, 0, 0), transform);
        yield return new WaitForSeconds(Random.value);//0 to 1 inclusive both ways
        StartCoroutine(Drop());
        //recursion used to drop coins between 2 bounds at random repedetly
    }

    public Vector2 DropPosition()
    {
        float x = Random.value*(bound2.x-bound1.x)+bound1.x;
        float y = Random.value * (bound2.y - bound1.y) + bound1.y;
        return new Vector2(x, y);
    }
}