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
            case PurchaseType.Gnome:
                if (GlobalCount.currentTotal >= GnomeUpgrade.grassNeeded[GnomeUpgrade.index])
                {
                    GlobalCount.currentTotal -= GnomeUpgrade.grassNeeded[GnomeUpgrade.index];
                    GnomeUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.gnomeUpgrade = GnomeUpgrade.upgrade;

                    GnomeUpgrade.index += 1;
                    SaveManager.Instance.gameData.gnomeIndex = GnomeUpgrade.index;
                }
                break;
            case PurchaseType.Bunny:
                if (GlobalCount.currentTotal >= BunnyUpgrade.grassNeeded[BunnyUpgrade.index])
                {
                    GlobalCount.currentTotal -= BunnyUpgrade.grassNeeded[BunnyUpgrade.index];
                    BunnyUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.bunnyUpgrade = BunnyUpgrade.upgrade;

                    BunnyUpgrade.index += 1;
                    SaveManager.Instance.gameData.bunnyIndex = BunnyUpgrade.index;
                }
                break;
            case PurchaseType.Mower:
                if (GlobalCount.currentTotal >= MowerUpgrade.grassNeeded[MowerUpgrade.index])
                {
                    GlobalCount.currentTotal -= MowerUpgrade.grassNeeded[MowerUpgrade.index];
                    MowerUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.mowerUpgrade = MowerUpgrade.upgrade;

                    MowerUpgrade.index += 1;
                    SaveManager.Instance.gameData.mowerIndex = MowerUpgrade.index;
                }
                break;
            case PurchaseType.Gardener:
                if (GlobalCount.currentTotal >= GardenerUpgrade.grassNeeded[GardenerUpgrade.index])
                {
                    GlobalCount.currentTotal -= GardenerUpgrade.grassNeeded[GardenerUpgrade.index];
                    GardenerUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.gardenerUpgrade = GardenerUpgrade.upgrade;

                    GardenerUpgrade.index += 1;
                    SaveManager.Instance.gameData.gardenerIndex = GardenerUpgrade.index;
                }
                break;
            case PurchaseType.Max:
                if (GlobalCount.currentTotal >= MaxUpgrade.grassNeeded[MaxUpgrade.index])
                {
                    GlobalCount.currentTotal -= MaxUpgrade.grassNeeded[MaxUpgrade.index];
                    MaxUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.maxUpgrade = MaxUpgrade.upgrade;

                    MaxUpgrade.index += 1;
                    SaveManager.Instance.gameData.maxIndex = MaxUpgrade.index;
                }
                break;
            case PurchaseType.Coin:
                if (GlobalCount.currentTotal >= CoinUpgrade.grassNeeded[CoinUpgrade.index])
                {
                    GlobalCount.currentTotal -= CoinUpgrade.grassNeeded[CoinUpgrade.index];
                    CoinUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.coinUpgrade = CoinUpgrade.upgrade;

                    CoinUpgrade.index += 1;
                    SaveManager.Instance.gameData.coinIndex = CoinUpgrade.index;
                }
                break;
            case PurchaseType.MrLeaf:
                if (GlobalCount.currentTotal >= LeafUpgrade.grassNeeded[LeafUpgrade.index])
                {
                    GlobalCount.currentTotal -= MowerUpgrade.grassNeeded[LeafUpgrade.index];
                    LeafUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.leafUpgrade = LeafUpgrade.upgrade;

                    LeafUpgrade.index += 1;
                    SaveManager.Instance.gameData.leafIndex = LeafUpgrade.index;
                }
                break;
            case PurchaseType.GrassGPT:
                if (GlobalCount.currentTotal >= GPTUpgrade.grassNeeded[GPTUpgrade.index])
                {
                    GlobalCount.currentTotal -= GPTUpgrade.grassNeeded[GPTUpgrade.index];
                    GPTUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.gptUpgrade = GPTUpgrade.upgrade;

                    GPTUpgrade.index += 1;
                    SaveManager.Instance.gameData.gptIndex = GPTUpgrade.index;
                }
                break;
            case PurchaseType.Gigaworm:
                if (GlobalCount.currentTotal >= WormUpgrade.grassNeeded[WormUpgrade.index])
                {
                    GlobalCount.currentTotal -= WormUpgrade.grassNeeded[WormUpgrade.index];
                    WormUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.wormUpgrade = WormUpgrade.upgrade;

                    WormUpgrade.index += 1;
                    SaveManager.Instance.gameData.wormIndex = WormUpgrade.index;
                }
                break;
            case PurchaseType.Grassbot:
                if (GlobalCount.currentTotal >= BotUpgrade.grassNeeded[BotUpgrade.index])
                {
                    GlobalCount.currentTotal -= BotUpgrade.grassNeeded[BotUpgrade.index];
                    BotUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.botUpgrade = BotUpgrade.upgrade;

                    BotUpgrade.index += 1;
                    SaveManager.Instance.gameData.botIndex = BotUpgrade.index;
                }
                break;
            case PurchaseType.Midas:
                if (GlobalCount.currentTotal >= MidasUpgrade.grassNeeded[MidasUpgrade.index])
                {
                    GlobalCount.currentTotal -= MidasUpgrade.grassNeeded[MidasUpgrade.index];
                    MidasUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.midasUpgrade = MidasUpgrade.upgrade;

                    MidasUpgrade.index += 1;
                    SaveManager.Instance.gameData.midasIndex = MidasUpgrade.index;
                }
                break;
            case PurchaseType.Dryad:
                if (GlobalCount.currentTotal >= DryadUpgrade.grassNeeded[DryadUpgrade.index])
                {
                    GlobalCount.currentTotal -= DryadUpgrade.grassNeeded[DryadUpgrade.index];
                    DryadUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.dryadUpgrade = DryadUpgrade.upgrade;

                    DryadUpgrade.index += 1;
                    SaveManager.Instance.gameData.dryadIndex = DryadUpgrade.index;
                }
                break;
            case PurchaseType.Grassman:
                if (GlobalCount.currentTotal >= GmanUpgrade.grassNeeded[GmanUpgrade.index])
                {
                    GlobalCount.currentTotal -= GmanUpgrade.grassNeeded[GmanUpgrade.index];
                    GmanUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.gmanUpgrade = GmanUpgrade.upgrade;

                    GmanUpgrade.index += 1;
                    SaveManager.Instance.gameData.gmanIndex = GmanUpgrade.index;
                }
                break;
            case PurchaseType.Grask:
                if (GlobalCount.currentTotal >= GraskUpgrade.grassNeeded[GraskUpgrade.index])
                {
                    GlobalCount.currentTotal -= GraskUpgrade.grassNeeded[GraskUpgrade.index];
                    GraskUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.graskUpgrade = GraskUpgrade.upgrade;

                    GraskUpgrade.index += 1;
                    SaveManager.Instance.gameData.graskIndex = GraskUpgrade.index;
                }
                break;
            case PurchaseType.Portal:
                if (GlobalCount.currentTotal >= PortalUpgrade.grassNeeded[PortalUpgrade.index])
                {
                    GlobalCount.currentTotal -= PortalUpgrade.grassNeeded[PortalUpgrade.index];
                    PortalUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.portalUpgrade = PortalUpgrade.upgrade;

                    PortalUpgrade.index += 1;
                    SaveManager.Instance.gameData.portalIndex = PortalUpgrade.index;
                }
                break;
            case PurchaseType.Tree:
                if (GlobalCount.currentTotal >= TreeUpgrade.grassNeeded[TreeUpgrade.index])
                {
                    GlobalCount.currentTotal -= TreeUpgrade.grassNeeded[TreeUpgrade.index];
                    TreeUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.treeUpgrade = TreeUpgrade.upgrade;

                    TreeUpgrade.index += 1;
                    SaveManager.Instance.gameData.treeIndex = TreeUpgrade.index;
                }
                break;
            case PurchaseType.Lawnfather:
                if (GlobalCount.currentTotal >= FatherUpgrade.grassNeeded[FatherUpgrade.index])
                {
                    GlobalCount.currentTotal -= FatherUpgrade.grassNeeded[FatherUpgrade.index];
                    FatherUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.fatherUpgrade = FatherUpgrade.upgrade;

                    FatherUpgrade.index += 1;
                    SaveManager.Instance.gameData.fatherIndex = FatherUpgrade.index;
                }
                break;
            case PurchaseType.God:
                if (GlobalCount.currentTotal >= GodUpgrade.grassNeeded[GodUpgrade.index])
                {
                    GlobalCount.currentTotal -= GodUpgrade.grassNeeded[GodUpgrade.index];
                    GodUpgrade.upgrade *= 2;
                    SaveManager.Instance.gameData.godUpgrade = GodUpgrade.upgrade;

                    GodUpgrade.index += 1;
                    SaveManager.Instance.gameData.godIndex = GodUpgrade.index;
                }
                break;
        }
        questManager.UpdateQuestProgress("PurchaseUpgrade", 1);
        achievementManager.UpdateQuestProgress("PurchaseUpgrade", 1);
    }

}