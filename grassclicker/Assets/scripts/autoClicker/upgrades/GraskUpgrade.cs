using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GraskUpgrade : MonoBehaviour
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
        "Sporeling Infestation", "Root Leech", "Chlorophyll Drainer", "Creeping Tendrils", "Soil Corruption",
        "Seed of Hunger", "Fungal Webbing", "Chloroswarm", "Verdant Plague", "Spore Wormhole",
        "Cosmic Swarm", "Dimensional Hivemind", "The Green Maw", "Apocalypse of Green", "The Infinite Gigaworm"

    };

    public static double[] grassNeeded = {
        7e19, 7e20, 7e22, 7e24, 7e26,
        7e29, 7e32, 7e35, 7e38, 7e42,
        7e46, 7e50, 7e54, 7e58, 7e62
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.graskUpgrade;
        index = SaveManager.Instance.gameData.graskIndex;
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

