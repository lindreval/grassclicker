using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MowerUpgrade : MonoBehaviour
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
        "Sharpened Blades", "Premium Gas", "Bigger Blades", "New Engine", "Diamond Blades",
        "Rocket Fuel", "Robotic Upgrade", "Magical Oil Change", "Laser Blades", "Portal Storage",
        "Galaxy Blades", "Dimensional Fuel", "FTL Motor", "Outerversal Wheels", "Reality Engine"

    };

    public static double[] grassNeeded = {
        5e7, 5e8, 5e10, 5e12, 5e14,
        5e17, 5e20, 5e23, 5e26, 5e30,
        5e34, 5e38, 5e42, 5e46, 5e50
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.mowerUpgrade;
        index = SaveManager.Instance.gameData.mowerIndex;
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

