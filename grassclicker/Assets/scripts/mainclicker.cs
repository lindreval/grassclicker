using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class mainclicker : MonoBehaviour
{
    public static double clickValue;

    public void ClickButton()
    {
        clickValue = 1;

        GlobalCount.totalCount += clickValue;
    }
}
