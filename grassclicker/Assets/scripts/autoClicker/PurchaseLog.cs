using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
public enum PurchaseType
{
    Clicker,
    Clipper,
    Gnome
}

public class PurchaseLog : MonoBehaviour
{
    public GameObject AutoClicker;
    public PurchaseType purchaseType;
    public DailyQuestManager questManager;
    public AchievementManager achievementManager;


    public void StartAutoClicker()
    {
        AutoClicker.SetActive(true);
        switch (purchaseType)
        {
            case PurchaseType.Clipper:
                if (GlobalCount.currentTotal >= GlobalClippers.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalClippers.grassNeeded;
                    GlobalClippers.level++;
                }
                break;
            case PurchaseType.Gnome:
                if (GlobalCount.currentTotal >= GlobalGnome.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalGnome.grassNeeded;
                    GlobalClippers.level++;
                }
                break;
        }

        questManager.UpdateQuestProgress("Purchase10Producers", 1);
        achievementManager.UpdateQuestProgress("Purchase10Producers", 1);
    }

    public void PurchaseUpgrade()
    {
        switch (purchaseType)
        {
            case PurchaseType.Clicker:
                if (GlobalCount.currentTotal >= ClickerUpgrade.grassNeeded)
                {
                    GlobalCount.currentTotal -= ClickerUpgrade.grassNeeded;
                    ClickerUpgrade.upgrade *= 2;
                }
                break;
            case PurchaseType.Clipper:
                if (GlobalCount.currentTotal >= ClipperUpgrade.grassNeeded)
                {
                    GlobalCount.currentTotal -= ClipperUpgrade.grassNeeded;
                    ClipperUpgrade.upgrade *= 2;
                }
                break;
        }
        questManager.UpdateQuestProgress("PurchaseUpgrade", 1);
        achievementManager.UpdateQuestProgress("PurchaseUpgrade", 1);
    }

}