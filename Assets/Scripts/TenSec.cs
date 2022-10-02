using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TenSec: MonoBehaviour
{
    public int next = 0;
    void Start()
    {
        StartCoroutine(tenSec());
    }

    IEnumerator tenSec()
    {
        yield return new WaitForSeconds(10.1f);
        SceneManager.LoadScene(next);
    }
}
