using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BotUpgrade : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI main;
    public TextMeshProUGUI description;
    public TextMeshProUGUI price;

    public static int upgrade;


    public int[] levels = {
        10, 25, 50, 100, 150, 200, 250, 300, 350, 400, 450, 500, 550, 600, 1000
    };

    public GameObject icon;

    public GameObject backdrop;

    private string[] names = {
        "Steel Plating", "High Speed Servos", "Precision Optics", "Solar Charging", "Advanced Weed Recognition",
        "Diamond Plating", "Turbo Cooling", "Grass Compression Tank", "Antigravity Hovering", "Nanobot Upgrade",
        "Quantum Processing Core", "Dimensional Mother Chip", "Impossible Computing", "Outerversal Intelligence", "The All-Knowing Computer"
    };

    public static double[] grassNeeded = {
        2e15, 2e16, 2e18, 2e20, 2e22,
        2e25, 2e28, 2e31, 2e34, 2e38,
        2e42, 2e46, 2e50, 2e54, 2e58
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.botUpgrade;
        index = SaveManager.Instance.gameData.botIndex;
    }

    void Update()
    {
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        button.interactable = GlobalCount.currentTotal >= grassNeeded[index];
       
        backdrop.SetActive(GlobalClippers.level > levels[index]);
        
        price.text = GlobalCount.FormatLargeNumber(grassNeeded[index]);

        main.text = names[index];

        if (GlobalCount.currentTotal < grassNeeded[index])
        {
            backdrop.GetComponent<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
        }
        else
        {
            backdrop.GetComponent<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }
    }
}

