using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ClickerUpgrade : MonoBehaviour
{
    public Button button;
    public TextMeshProUGUI main;
    public TextMeshProUGUI description;
    public TextMeshProUGUI price;

    public static int upgrade;


    public double[] levels = {
        5e5, 5e6, 5e7, 5e10, 5e12,
        5e15, 5e18, 5e21, 5e24, 5e28,
        5e32, 5e36, 5e40, 5e44, 5e48
    };

    public GameObject icon;

    public GameObject backdrop;

    private string[] names = {
        "Finger Strengthener", "Calloused Thumb", "Heavy Finger", "6th Finger", "Clicker Gloves",
        "Mechanical Splint", "Touch Mastery", "Bionic Fingertip", "Ultra Tap", "1000 years of Tap",
        "Touch Enlightement", "Quantum Tapping", "FTL Reflex", "Cosmic Touch", "Reality Click"

    };

    public static double[] grassNeeded = {
        5e3, 5e4, 5e6, 5e8, 5e10,
        5e13, 5e16, 5e19, 5e22, 5e26,
        5e30, 5e34, 5e38, 5e42, 5e46
    };

    public static int index;

    void Start()
    {
        upgrade = SaveManager.Instance.gameData.clickerUpgrade;
    }

    void Update()
    {
        CheckForUpgrade();
        button.interactable = GlobalCount.gemTotal >= 10;
    }

    private void CheckForUpgrade()
    {
        button.interactable = GlobalCount.currentTotal >= grassNeeded[index];
       
        backdrop.SetActive(GlobalCount.allTimeCount > levels[index]);
        
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

