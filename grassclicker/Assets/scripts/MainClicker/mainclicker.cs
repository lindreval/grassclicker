using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class mainclicker : MonoBehaviour
{
    public static double clickValue;

    public DailyQuestManager questManager;
    public AchievementManager achievementManager;

    void Start()
    {
        clickValue = 1;
    }

    public void ClickButton()
    {
        GlobalCount.currentTotal += clickValue * ClickerUpgrade.upgrade;
        GlobalCount.allTimeCount += clickValue * ClickerUpgrade.upgrade;
        questManager.UpdateQuestProgress("TouchGrass", 1);
        achievementManager.UpdateQuestProgress("TouchGrassAmount", 1);
    }
}
