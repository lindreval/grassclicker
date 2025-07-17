using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PrestigeManager : MonoBehaviour
{
    public static double currentUltra;
    public static double ultraGain;

    void Start()
    {
        currentUltra = 0;
    }

    public void Prestige()
    {
        GlobalCount.currentTotal = 0;

        GlobalClippers.perSec = 0;
        GlobalClippers.level = 0;
        ClipperUpgrade.upgrade = 0;

        currentUltra += ultraGain;
    }
}
