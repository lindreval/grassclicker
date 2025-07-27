using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
public enum PurchaseType
{
    Clicker,
    Clipper,
    Gnome,
    Bunny,
    Mower,
    Gardener,
    Max,
    Coin,
    MrLeaf,
    GrassGPT,
    Gigaworm,
    Grassbot,
    Midas,
    Dryad,
    Mowdok,
    Grassman,
    Grask,
    Tree,
    Portal,
    Lawnfather,
    God
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
                    SaveManager.Instance.gameData.clipperLevel = GlobalClippers.level;
                }
                break;
            case PurchaseType.Gnome:
                if (GlobalCount.currentTotal >= GlobalGnome.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalGnome.grassNeeded;
                    GlobalGnome.level++;
                    SaveManager.Instance.gameData.gnomeLevel = GlobalGnome.level;
                }
                break;
            case PurchaseType.Bunny:
                if (GlobalCount.currentTotal >= GlobalBunny.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalBunny.grassNeeded;
                    GlobalBunny.level++;
                    SaveManager.Instance.gameData.bunnyLevel = GlobalBunny.level;
                }
                break;
            case PurchaseType.Mower:
                if (GlobalCount.currentTotal >= GlobalMower.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalMower.grassNeeded;
                    GlobalMower.level++;
                    SaveManager.Instance.gameData.mowerLevel = GlobalMower.level;
                }
                break;
            case PurchaseType.Gardener:
                if (GlobalCount.currentTotal >= GlobalGardener.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalGardener.grassNeeded;
                    GlobalGardener.level++;
                    SaveManager.Instance.gameData.gardenerLevel = GlobalGardener.level;
                }
                break;
            case PurchaseType.Max:
                if (GlobalCount.currentTotal >= GlobalMax.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalMax.grassNeeded;
                    GlobalMax.level++;
                    SaveManager.Instance.gameData.maxLevel = GlobalMax.level;
                }
                break;
            case PurchaseType.Coin:
                if (GlobalCount.currentTotal >= GlobalCoin.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalCoin.grassNeeded;
                    GlobalCoin.level++;
                    SaveManager.Instance.gameData.coinLevel = GlobalCoin.level;
                }
                break;
            case PurchaseType.MrLeaf:
                if (GlobalCount.currentTotal >= GlobalLeaf.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalLeaf.grassNeeded;
                    GlobalLeaf.level++;
                    SaveManager.Instance.gameData.leafLevel = GlobalLeaf.level;
                }
                break;
            case PurchaseType.GrassGPT:
                if (GlobalCount.currentTotal >= GlobalGPT.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalGPT.grassNeeded;
                    GlobalGPT.level++;
                    SaveManager.Instance.gameData.gptLevel = GlobalGPT.level;
                }
                break;
            case PurchaseType.Gigaworm:
                if (GlobalCount.currentTotal >= GlobalWorm.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalWorm.grassNeeded;
                    GlobalWorm.level++;
                    SaveManager.Instance.gameData.wormLevel = GlobalWorm.level;
                }
                break;
            case PurchaseType.Grassbot:
                if (GlobalCount.currentTotal >= GlobalBot.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalBot.grassNeeded;
                    GlobalBot.level++;
                    SaveManager.Instance.gameData.botLevel = GlobalBot.level;
                }
                break;
            case PurchaseType.Midas:
                if (GlobalCount.currentTotal >= GlobalMidas.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalMidas.grassNeeded;
                    GlobalMidas.level++;
                    SaveManager.Instance.gameData.midasLevel = GlobalMidas.level;
                }
                break;
            case PurchaseType.Dryad:
                if (GlobalCount.currentTotal >= GlobalDryad.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalDryad.grassNeeded;
                    GlobalDryad.level++;
                    SaveManager.Instance.gameData.dryadLevel = GlobalDryad.level;
                }
                break;
            case PurchaseType.Mowdok:
                if (GlobalCount.currentTotal >= GlobalAlien.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalAlien.grassNeeded;
                    GlobalAlien.level++;
                    SaveManager.Instance.gameData.alienLevel = GlobalAlien.level;
                }
                break;
            case PurchaseType.Grassman:
                if (GlobalCount.currentTotal >= GlobalGMan.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalGMan.grassNeeded;
                    GlobalGMan.level++;
                    SaveManager.Instance.gameData.gmanLevel = GlobalGMan.level;
                }
                break;
            case PurchaseType.Grask:
                if (GlobalCount.currentTotal >= GlobalGrask.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalGrask.grassNeeded;
                    GlobalGrask.level++;
                    SaveManager.Instance.gameData.graskLevel = GlobalGrask.level;
                }
                break;
            case PurchaseType.Tree:
                if (GlobalCount.currentTotal >= GlobalTree.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalTree.grassNeeded;
                    GlobalTree.level++;
                    SaveManager.Instance.gameData.treeLevel = GlobalTree.level;
                }
                break;
            case PurchaseType.Portal:
                if (GlobalCount.currentTotal >= GlobalPortal.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalPortal.grassNeeded;
                    GlobalPortal.level++;
                    SaveManager.Instance.gameData.portalLevel = GlobalPortal.level;
                }
                break;
            case PurchaseType.Lawnfather:
                if (GlobalCount.currentTotal >= GlobalFather.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalFather.grassNeeded;
                    GlobalFather.level++;
                    SaveManager.Instance.gameData.fatherLevel = GlobalFather.level;
                }
                break;
            case PurchaseType.God:
                if (GlobalCount.currentTotal >= GlobalGod.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalGod.grassNeeded;
                    GlobalGod.level++;
                    SaveManager.Instance.gameData.godLevel = GlobalGod.level;
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
                if (GlobalCount.currentTotal >= ClickerUpgrade.grassNeeded[ClickerUpgrade.index])
                {
                    GlobalCount.currentTotal -= ClickerUpgrade.grassNeeded[ClickerUpgrade.index];
                    ClickerUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.clickerUpgrade = ClickerUpgrade.upgrade;

                    ClickerUpgrade.index += 1;
                    SaveManager.Instance.gameData.clipperIndex = ClickerUpgrade.index;
                }
                break;
            case PurchaseType.Clipper:
                if (GlobalCount.currentTotal >= ClipperUpgrade.grassNeeded[ClipperUpgrade.index])
                {
                    GlobalCount.currentTotal -= ClipperUpgrade.grassNeeded[ClipperUpgrade.index];
                    ClipperUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.clipperUpgrade = ClipperUpgrade.upgrade;

                    ClipperUpgrade.index += 1;
                    SaveManager.Instance.gameData.clipperIndex = ClipperUpgrade.index;
                }
                break;
        }
        questManager.UpdateQuestProgress("PurchaseUpgrade", 1);
        achievementManager.UpdateQuestProgress("PurchaseUpgrade", 1);
    }

}