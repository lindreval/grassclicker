using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AlienUpgrade : MonoBehaviour
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
        "Chloroplast Visor", "Photosynthesis Ray", "Hover Harvesters", "Lawntractor Beam", "Galactic Fertilizer",
        "Soil Pods", "Plasma Clippers", "Zero G Grow Beds", "Unidentifiable Floating Grass", "Xeno-Symbionts",
        "Cosmic Turf Scanner", "Dimensional Reactor", "The Greening Beam", "Grass Nebula", "Overlord of the Green"

    };

    public static double[] grassNeeded = {
        5e17, 5e18, 5e20, 5e22, 5e24,
        5e27, 5e30, 5e33, 5e36, 5e40,
        5e44, 5e48, 5e52, 5e56, 5e60
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.alienUpgrade;
        index = SaveManager.Instance.gameData.alienIndex;
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

