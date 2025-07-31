using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GnomeUpgrade : MonoBehaviour
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
        "Pointer Hats", "Ceramic Armor", "Beard Wax", "Polished Finish", "Moveable Limbs",
        "Minature Mowers", "Robotic Modifications", "Luck of the Four-Leaf Clover", "Blessing of the Mushroom", "Magical Staff",
        "Gnome Union", "Quantum Robes", "FTL Boots", "'Outerversal Caps'", "Reality Beards"

    };

    public static double[] grassNeeded = {
        3e5, 3e6, 3e8, 3e10, 3e12,
        3e15, 3e18, 3e21, 3e24, 3e28,
        3e32, 3e36, 3e40, 3e44, 3e48
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.gnomeUpgrade;
        index = SaveManager.Instance.gameData.gnomeIndex;
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

