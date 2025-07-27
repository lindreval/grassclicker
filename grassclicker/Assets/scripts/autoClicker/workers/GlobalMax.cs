using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GlobalMax : MonoBehaviour
{
    public Button button;
    public GameObject backdrop;
    public Image icon;

    public TextMeshProUGUI mainText;
    public TextMeshProUGUI statsText;
    public TextMeshProUGUI description;
    public TextMeshProUGUI price;
    public TextMeshProUGUI levelText;

    public static int level;
    public static double perSec;
    public static double grassNeeded;

    void Start()
    {
       level = SaveManager.Instance.gameData.maxLevel;
    }

    void Update()
    {
        UpdateButtonState();
        UpdateCPS();
        grassNeeded = Math.Round(Math.Pow(1.15, level) * 1990000);
    }

    private void UpdateCPS()
    {
        perSec = 1450 * level;
    }

    private void UpdateButtonState()
    {
        button.interactable = GlobalCount.currentTotal >= grassNeeded;

        if (GlobalGardener.level >= 1)
        {
            backdrop.SetActive(true);
        }
        else
        {
            backdrop.SetActive(false);
        }

        if (GlobalCount.currentTotal < grassNeeded)
        {
            backdrop.GetComponent<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
        }
        else
        {
            backdrop.GetComponent<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }

        if (level == 0)
        {
            mainText.text = "???";
            statsText.text = "";
            levelText.text = "";

            icon.color = Color.black;
        }
        else
        {
            mainText.text = "Grassmaxxer";
            statsText.text = GlobalCount.FormatLargeNumber(perSec) + " grass per sec";
            levelText.text = level.ToString();

            icon.color = Color.white;
        }

        description.text = "Taking grass touching to the extreme";
        price.text = GlobalCount.FormatLargeNumber(grassNeeded);
        levelText.text = GlobalCount.FormatLargeNumber(level);
    }
}