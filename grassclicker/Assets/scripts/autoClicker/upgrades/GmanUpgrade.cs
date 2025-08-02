using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GmanUpgrade : MonoBehaviour
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
        "Cape of Green", "Mask of the Meadow", "Photosythensis Punch", "Weed Sense", "Green Beam",
        "The Green Fist", "Turbo Lawn Boots", "Man of Grass", "Turf Flight", "The Sod Shield",
        "Suit of Sod", "Cosmic Grass Beam", "Dimensional Green Punch", "Grass of Hope", "The Number One Hero"

    };

    public static double[] grassNeeded = {
        6e18, 6e19, 6e21, 6e23, 6e25,
        6e28, 6e31, 6e34, 6e37, 6e41,
        6e45, 6e49, 6e53, 6e57, 6e61
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.gmanUpgrade;
        index = SaveManager.Instance.gameData.gmanIndex;
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

