using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
public enum PurchaseType
{
    Clipper
}

public class PurchaseLog : MonoBehaviour
{
    public GameObject AutoClicker;
    public PurchaseType purchaseType;


    public void StartAutoClicker()
    {
        AutoClicker.SetActive(true);
        switch (purchaseType)
        {
            case PurchaseType.Clipper:
                if (GlobalCount.currentTotal >= GlobalClippers.grassNeeded)
                {
                    GlobalCount.currentTotal -= GlobalClippers.grassNeeded;
                    GlobalClippers.perSec += 0.1f * Mathf.Pow(1.01f, GlobalClippers.level);
                    GlobalClippers.level++;
                }
                break;
        }
    }

}