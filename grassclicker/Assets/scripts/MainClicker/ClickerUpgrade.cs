using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ClickerUpgrade : MonoBehaviour
{
    public static int upgrade;
    public GameObject backdrop;
    public GameObject icon;
    public Button button;
    public TextMeshProUGUI main;
    public TextMeshProUGUI description;
    public TextMeshProUGUI price;
    

    public static int index;

    public static double[] grassNeeded = {
        20, 30
    };

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
        backdrop.GetComponent<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        if (AutoClicker.countIncrease > 0.10 && upgrade == 1)
        {
            backdrop.SetActive(true);
        }
        else
        {
            backdrop.SetActive(false);
        }
        price.text = GlobalCount.FormatLargeNumber(grassNeeded[index]);
    }
}

