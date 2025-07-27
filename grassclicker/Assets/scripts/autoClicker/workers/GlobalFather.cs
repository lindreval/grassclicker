using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GlobalFather : MonoBehaviour
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
       level = SaveManager.Instance.gameData.fatherLevel;
    }

    void Update()
    {
        UpdateButtonState();
        UpdateCPS();
        grassNeeded = Math.Round(Math.Pow(1.15, level) * 2.6e24);
    }

    private void UpdateCPS()
    {
        perSec = 7.55e14 * level;
    }


    private void UpdateButtonState()
    {
        button.interactable = GlobalCount.currentTotal >= grassNeeded;

        if (GlobalTree.level >= 1)
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
            mainText.text = "The Lawn Father";
            statsText.text = GlobalCount.FormatLargeNumber(perSec) + " grass per sec";
            levelText.text = level.ToString();

            icon.color = Color.white;
        }

        description.text = "You come to him... for a clean trim";
        price.text = GlobalCount.FormatLargeNumber(grassNeeded);
        levelText.text = GlobalCount.FormatLargeNumber(level);
    }
}