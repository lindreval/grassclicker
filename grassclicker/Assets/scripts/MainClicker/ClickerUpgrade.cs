using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ClickerUpgrade : MonoBehaviour
{
    public static double upgrade;
    public GameObject backdrop;
    public GameObject icon;
    public Button button;
    public TextMeshProUGUI main;
    public TextMeshProUGUI description;
    public TextMeshProUGUI price;
    public static double grassNeeded;

    void Start()
    {
        if (!PlayerPrefs.HasKey("FirstTimeOpened"))
        {
            upgrade = 1;

            PlayerPrefs.SetInt("FirstTimeOpened", 1);
            PlayerPrefs.Save();
        }
        upgrade = 1;
    }

    void Update()
    {
        CheckForUpgrade();
        button.interactable = GlobalCount.gemTotal >= 10;
    }

    private void CheckForUpgrade()
    {
        backdrop.GetComponent<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        if (AutoClicker.countIncrease > 0.10 && upgrade == 1)
        {
            backdrop.SetActive(true);
        }
        else
        {
            backdrop.SetActive(false);
        }
        price.text = GlobalCount.FormatLargeNumber(grassNeeded);
    }
}

