using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalController : MonoBehaviour
{
    public ChemicalMixer cm;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {

        }
    }

    public bool ChemicalSelect(int d)//direction
    {
        return cm.chemicals[d].isToxic;
    }
}