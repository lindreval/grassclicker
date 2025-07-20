using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GlobalGnome : MonoBehaviour
{
    public Button button;
    public GameObject backdrop;
    public GameObject icon;

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
        if (!PlayerPrefs.HasKey("FirstTimeOpened"))
        {
            grassNeeded = 10;
            perSec = 0;
            level = 0;

            PlayerPrefs.SetInt("FirstTimeOpened", 1);
            PlayerPrefs.Save();
        }
    }

    void Update()
    {
        UpdateButtonState();
        UpdateCPS();
        grassNeeded = Math.Round(Math.Pow(1.15, level) * 150);
    }

    private void UpdateCPS()
    {
        perSec = 1 * level;
    }

    private void UpdateButtonState()
    {
        button.interactable = GlobalCount.currentTotal >= grassNeeded;

        if (level == 0)
        {
            mainText.text = "???";
            statsText.text = "";
            levelText.text = "";

            backdrop.GetComponent<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 0.3f);
        }
        else
        {
            mainText.text = "Garden Gnome";
            statsText.text = GlobalCount.FormatLargeNumber(perSec) + " grass per sec";
            levelText.text = level.ToString();

            backdrop.GetComponent<UnityEngine.UI.Image>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
        }

        description.text = "Small, silent, and efficient at touching grass";
        price.text = GlobalCount.FormatLargeNumber(grassNeeded);
        levelText.text = GlobalCount.FormatLargeNumber(level);
    }
}
