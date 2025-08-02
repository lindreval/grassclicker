using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GodUpgrade : MonoBehaviour
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
        "Green Prayers", "Roots of Creations", "The Emerald Throne", "Turf Decree", "Verdant Commandments",
        "Grass Gospel", "Lawn Above the Clouds", "Angels of the Green", "Evergreen Pantheon", "Green Genesis",
        "Pasture Paradise", "Omnigrass", "One World Under Grass", "Emerald Convergance", "One World Under Grass"
    };

    public static double[] grassNeeded = {
        11e27, 11e28, 11e30, 11e32, 11e34,
        11e37, 11e40, 11e43, 11e46, 11e50,
        11e54, 11e58, 11e62, 11e66, 11e70
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.godUpgrade;
        index = SaveManager.Instance.gameData.godIndex;
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

