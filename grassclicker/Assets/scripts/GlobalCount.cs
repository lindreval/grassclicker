using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GlobalCount : MonoBehaviour
{
    public static double totalCount;
    public TextMeshProUGUI totalText;

    private void Update()
    {
        totalText.text = "Total = " + FormatLargeNumber(totalCount);
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
