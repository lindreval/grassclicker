using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradePurchaseType
{
    Clipper,
}

public class UpgradePurchaseLog : MonoBehaviour
{
    public UpgradePurchaseType purchaseType;


    public void PurchaseUpgrade()
    {
        switch (purchaseType)
        {
            case UpgradePurchaseType.Clipper:
                if (GlobalCount.currentTotal >= ClipperUpgrade.grassNeeded)
                {
                    GlobalCount.currentTotal -= ClipperUpgrade.grassNeeded;
                    ClipperUpgrade.upgrade += 1;
                    ClipperUpgrade.backdrop.SetActive(false);
                }
                break;
        }
    }
}
