using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ClipperUpgrade : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI main;
    public TextMeshProUGUI description;
    public TextMeshProUGUI price;

    public static int upgrade;


    public int[] levels = {
        50, 200, 300, 400, 500, 600, 700, 800, 900,
        1000, 1100, 1200, 1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000
    };

    public List<string> descriptions = new List<string>();

    public List<Image> icon = new List<Image>();

    public GameObject backdrop;

    public static double[] grassNeeded = {
        20, 30
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.clipperUpgrade;
        index = SaveManager.Instance.gameData.clipperIndex;
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

        main.text = descriptions[index];

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

