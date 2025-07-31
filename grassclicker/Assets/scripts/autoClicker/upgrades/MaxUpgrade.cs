using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MaxUpgrade : MonoBehaviour
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
        "Grass and Grind", "Grass Diet", "Blade Bro", "Shrub Shredder", "'Just touch grass bro'",
        "Grass Dumbells", "Grass Salt Spray", "Grass Skincare", "Positive Grassthal Tilt", "Grass Tinted Eye",
        "Garden Mogged", "Dimensional Grassarms", "FTL Dewing", "Grassversal Jawline", "King Grassmaxxer"

    };

    public static double[] grassNeeded = {
        7e9, 7e10, 7e12, 7e14, 7e16,
        7e19, 7e22, 7e25, 7e28, 7e32,
        7e36, 7e40, 7e44, 7e48, 7e52
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.maxUpgrade;
        index = SaveManager.Instance.gameData.maxIndex;
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

