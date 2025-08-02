using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MidasUpgrade : MonoBehaviour
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
        "Green Thumb Touch", "Emerald Fingertips", "Verdant Crown", "Grass Skin", "Clover Blessing",
        "Green Blood", "Blades of Fortune", "Turf Transmutation", "Emerald Gauntlets", "Evergreen Handshake",
        "Green Throne", "Suffering From Success", "Verdant Divinity", "Planet of Sod", "The Grass King"

    };

    public static double[] grassNeeded = {
        3e15, 3e16, 3e18, 3e20, 3e22,
        3e25, 3e28, 3e31, 3e34, 3e38,
        3e42, 3e46, 3e50, 3e54, 3e58
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.midasUpgrade;
        index = SaveManager.Instance.gameData.midasIndex;
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

