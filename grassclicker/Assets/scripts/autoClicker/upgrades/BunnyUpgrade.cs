using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BunnyUpgrade : MonoBehaviour
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
        "Healthy Carrot", "Bouncy Boots", "Burrow Network", "Never Skip Leg Day", "Steel Teeth",
        "Lettuce Rewards Program", "Diamond Fur", "Golden Carrots", "Cyber Boots", "Magical Thumpers",
        "Galaxy Carrots", "Dimensional Burrows", "FTL Teeth", "Outerversal Fur", "Reality Hops"

    };

    public static double[] grassNeeded = {
        4e6, 4e7, 4e9, 4e11, 4e13,
        4e16, 4e19, 4e22, 4e25, 4e29,
        4e33, 4e37, 4e41, 4e45, 4e49
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.bunnyUpgrade;
        index = SaveManager.Instance.gameData.bunnyIndex;
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

