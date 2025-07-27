using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalCount : MonoBehaviour
{
    public static double currentTotal;
    public static double allTimeCount;
    public static double gemTotal;
    public TextMeshProUGUI totalText;
    public TextMeshProUGUI perSecText;

    void Start()
    {
        currentTotal = SaveManager.Instance.gameData.currentTotal;
        allTimeCount = SaveManager.Instance.gameData.allTimeCount;
        gemTotal = SaveManager.Instance.gameData.gemTotal;
    }

    private void Update()
    {
        totalText.text = "Total = " + FormatLargeNumber(currentTotal);
        perSecText.text = FormatLargeNumber(AutoClicker.countIncrease) + " grass touched/sec";

        //Save
        SaveManager.Instance.gameData.currentTotal = currentTotal;
    }
    
    public static string FormatLargeNumber(double number)
    {
        string[] suffixes = { "", "K", "M", "B", "T", "Qa", "Qi", "Sx", "Sp", "Oc", "No", "Dc", "Ud", "Dd"}; // Add more as needed
        int suffixIndex = 0;

        // Reduce the number and find the correct suffix
        while (number >= 1000 && suffixIndex < suffixes.Length - 1)
        {
            number /= 1000;
            suffixIndex++;
        }

        // Format the number to two decimal places and append the suffix
        return $"{number:F2}{suffixes[suffixIndex]}";
    }

}
