using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GardenerUpgrade : MonoBehaviour
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
        "Experienced", "Green Thumb", "Toolbelt Upgrade", "Sun Hat", "Diamond Wheelbarrow",
        "Weed Detector", "Robotic Overalls", "Magical Watering Can", "Cyber Shovel", "Boots of Legend",
        "Ultra Visor", "Dimensional Hose", "FTL Gloves", "Outerversal Pitchfork", "Reality Fertilizer"

    };

    public static double[] grassNeeded = {
        6e8, 6e9, 6e11, 6e13, 6e15,
        6e18, 6e21, 6e24, 6e27, 6e31,
        6e35, 6e39, 6e43, 6e47, 6e51
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.gardenerUpgrade;
        index = SaveManager.Instance.gameData.gardenerIndex;
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

