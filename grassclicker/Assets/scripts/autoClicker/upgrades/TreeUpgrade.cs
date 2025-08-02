using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class TreeUpgrade : MonoBehaviour
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
        "Branches of Eternity", "Green Canopy", "Emerald Bark", "Photosynth Pulse", "World Sap",
        "Planetary Expansion", "Bloom Season", "Grove Spirit", "Dryad Guardian", "Meadow Core",
        "Mythical Bark", "Celestial Blossom", "Root Network of World", "Outerversal Grove", "Yggdrasil"

    };

    public static double[] grassNeeded = {
        9e23, 9e24, 9e26, 9e28, 9e30,
        9e33, 9e36, 9e39, 9e42, 9e46,
        9e50, 9e54, 9e58, 9e62, 9e66
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.treeUpgrade;
        index = SaveManager.Instance.gameData.treeIndex;
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

