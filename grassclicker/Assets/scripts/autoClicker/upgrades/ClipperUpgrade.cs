using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;


public class ClipperUpgrade : MonoBehaviour
{
    public Button button;
    public static GameObject backdrop;
    public TextMeshProUGUI description;
    public static double upgrade;
    public static double grassNeeded;

    void Start()
    {
        description.text = "placeholder";
        grassNeeded = 1;
        upgrade = 1;
    }
    void Update()
    {
        UpdateButtonState();
    }

    private void UpdateButtonState()
    {
        button.interactable = GlobalCount.currentTotal >= grassNeeded;

        if (GlobalClippers.level > 10)
        {
            button.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(false);
        }
    }

    public void PurchaseUpgrade()
    {
        GlobalCount.currentTotal -= grassNeeded;
        upgrade += 1;
        button.gameObject.SetActive(false);
    }
}

