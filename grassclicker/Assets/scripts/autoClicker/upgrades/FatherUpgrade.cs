using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FatherUpgrade : MonoBehaviour
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
        "Turf Syndicate", "Family of Fertilizer", "Sod Laundering", "Whispered Respect", "Blood and Mulch Oath",
        "Underground Root Conncections", "House of Green", "Turf Throne", "The Grass Enforcer", "The Fertilizer Front",
        "The Green Empire", "Cosmic Connections", "World of Grass", "The Eternal Don", "The Godfather of Grass"

    };

    public static double[] grassNeeded = {
        10e25, 10e26, 10e28, 10e30, 10e32,
        10e35, 10e38, 10e41, 10e44, 10e48,
        10e52, 10e56, 10e60, 10e64, 10e68
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.fatherUpgrade;
        index = SaveManager.Instance.gameData.fatherIndex;
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

