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
    public AchievementManager achievementManager;

    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstTimeOpened"))
        {
            currentUltra = 0;

            PlayerPrefs.SetInt("FirstTimeOpened", 1);
            PlayerPrefs.Save();
        }
    }

    public void Prestige()
    {
        GlobalCount.currentTotal = 0;

        GlobalClippers.level = 0;
        ClipperUpgrade.upgrade = 1;

        currentUltra += ultraGain;

        achievementManager.UpdateQuestProgress("Prestige", 1);
    }
}
