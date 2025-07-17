using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class mainclicker : MonoBehaviour
{
    public static double clickValue;

    public DailyQuestManager questManager;

    public void ClickButton()
    {
        clickValue = 1;

        GlobalCount.currentTotal += clickValue;
        questManager.UpdateQuestProgress("ClickQuest", 1);
    }
}
