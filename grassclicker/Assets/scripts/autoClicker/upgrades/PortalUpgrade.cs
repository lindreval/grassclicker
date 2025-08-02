using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PortalUpgrade : MonoBehaviour
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
        "Reality Crack", "Swift Slitering", "Chlorophyll Surge", "Map", "The Sod Rift",
        "Turfstorm Breach", "Green Gateway", "Gatekeeper", "The Lawn from Beyond", "Dimensional GPS",
        "Cosmic Crawling", "Into the Grassverse", "Multiversal Flood", "Outerversal Travel", "The Infinite Pasture"

    };

    public static double[] grassNeeded = {
        8e21, 8e22, 8e24, 8e26, 8e28,
        8e31, 8e34, 8e37, 8e40, 8e44,
        8e48, 8e52, 8e56, 8e60, 8e64
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.portalUpgrade;
        index = SaveManager.Instance.gameData.portalIndex;
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

