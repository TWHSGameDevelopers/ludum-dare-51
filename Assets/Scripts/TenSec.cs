using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TenSec: MonoBehaviour
{
    public int next = 0;
    public bool update = true;
    void Start()
    {
        StartCoroutine(tenSec());
    }

    IEnumerator tenSec()
    {
        yield return new WaitForSeconds(10.0f);
        if (update)
        {
            int[] s = new int[4];
            Controls[] controls =GetComponents<Controls>();
            int i =0;
            foreach(Controls c in controls)
            {
                s[i]=c.hitScript.score;
                i++;
            }
            ScoreTracker.UpdateScores(s);
            foreach(int j in ScoreTracker.scores)
            {
                print("score "+j);
            }
        }
        SceneManager.LoadScene(next);
    }
}
