using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DryadUpgrade : MonoBehaviour
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
        "Whispering Roots", "Oak Heart", "Blossom Aura", "Spirit Aids", "Flowering Staff",
        "Lullaby to the Leaves", "Moonlit Waltz", "Flowering Stadd", "Spirit of the Grove", "Magical Melody",
        "Cosmic Bloom", "Mother Nature", "World Tree's Guardian", "Verdant Queen", "Nature's Pulse"

    };

    public static double[] grassNeeded = {
        4e16, 4e17, 4e19, 4e21, 4e23,
        4e26, 4e29, 4e32, 4e35, 4e39,
        4e43, 4e47, 4e51, 4e55, 4e59
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.dryadUpgrade;
        index = SaveManager.Instance.gameData.dryadIndex;
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

