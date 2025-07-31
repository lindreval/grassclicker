using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LeafUpgrade : MonoBehaviour
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
        "100 Grass Giveaway", "Last to Leave the Lawn Wins!", "50 Hours Under a Yard", "", "Pump and Mow",
        "$1000 for Every Grass Blade", "Most Dangerous Lawn!", "$1 vs $1Bill Lawn", "7 Days on a Stranded Lawn", "Lawn Giveaway",
        "100 Gardeners vs 100 Lawns", "Building 100 Lawns", "Taking over the Market", "World's Most Expensive Lawn", "Return on Grassvestment"

    };

    public static double[] grassNeeded = {
        8e11, 8e12, 8e14, 8e16, 8e18,
        8e21, 8e24, 8e27, 8e30, 8e34,
        8e38, 8e42, 8e46, 8e50, 8e54
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.leafUpgrade;
        index = SaveManager.Instance.gameData.leafIndex;
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

