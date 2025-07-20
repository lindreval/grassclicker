using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class AutoClicker : MonoBehaviour
{
    public bool creatingBlank = false;
    public static double countIncrease;

    void Update()
    {
        countIncrease = ((GlobalClippers.perSec * ClipperUpgrade.upgrade)) * (1 + PrestigeManager.currentUltra);
        if (creatingBlank == false)
        {
            creatingBlank = true;
            StartCoroutine(CreateIt());
        }
    }

    IEnumerator CreateIt(){
        GlobalCount.currentTotal += countIncrease/5;
        GlobalCount.allTimeCount += countIncrease/5;
        yield return new WaitForSeconds(.2f);
        creatingBlank = false;
    }
}