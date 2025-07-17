using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GlobalClippers : MonoBehaviour
{
    public Button button;
    public GameObject backdrop;
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI statsText;

    public static int level;
    public static double perSec;
    public static double grassNeeded;

    void Start()
    {
        grassNeeded = 0;
        perSec = 0;
        level = 0;
    }

    private void UpdateDisplay()
    {
        mainText.text = "Clippers\n Lv: " + level;
        statsText.text = perSec + " grass per sec";
    }

    private void UpdateButtonState()
    {
        button.interactable = GlobalCount.currentTotal >= grassNeeded;

        if (level > 0)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = $"Upgrade:  \n$ {GlobalCount.FormatLargeNumber(grassNeeded)}";
        }
        else
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = $"Buy:  \n$ {GlobalCount.FormatLargeNumber(grassNeeded)}";
        }
    }
}
