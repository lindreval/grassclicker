using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class GlobalGMan : MonoBehaviour
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
       level = SaveManager.Instance.gameData.gmanLevel;
    }

    void Update()
    {
        UpdateButtonState();
        UpdateCPS();
        grassNeeded = Math.Round(Math.Pow(1.15, level) * 3.5e16);
    }

    private void UpdateCPS()
    {
        perSec = 2.5e11 * level;
    }

    private void UpdateButtonState()
    {
        button.interactable = GlobalCount.currentTotal >= grassNeeded;

        if (GlobalAlien.level >= 1)
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
            mainText.text = "G-Man";
            statsText.text = GlobalCount.FormatLargeNumber(perSec) + " grass per sec";
            levelText.text = level.ToString();

            icon.color = Color.white;
        }

        description.text = "The masked mower. Defender of lawns.";
        price.text = GlobalCount.FormatLargeNumber(grassNeeded);
        levelText.text = GlobalCount.FormatLargeNumber(level);
    }
}