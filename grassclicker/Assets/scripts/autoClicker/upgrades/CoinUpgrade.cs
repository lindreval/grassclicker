using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CoinUpgrade : MonoBehaviour
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
        "Buy low, sell Grass", "Earn Grass Quick!", "NFT(Nice Fresh Turf)", "Celebrity Shoutout", "Pump and Mow",
        "Grass Goes Up", "Green Rug Pull", "Turf Tokenomics", "Grass Coin Moonshot", "Enter the Grasschain",
        "ATGH(All Time Grass High)", "Hold on for Dear Grass", "Taking over the Market", "Outerversal Grass Whale", "Return on Grassvestment"

    };

    public static double[] grassNeeded = {
        7e10, 7e11, 7e13, 7e15, 7e17,
        7e20, 7e23, 7e26, 7e29, 7e33,
        7e37, 7e41, 7e45, 7e49, 7e53
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.coinUpgrade;
        index = SaveManager.Instance.gameData.coinIndex;
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

