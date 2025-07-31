using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GPTUpgrade : MonoBehaviour
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
        "Version Alpha", "AI Powered Mulching", "Photosynthesis Prompting", "Autonomous GrassGPT", "Mowdel 2.0",
        "Clipper Optimiziation", "Blade Training Data", "AI-Generated Lawns", "Singulawnrity", "Realistic AI Grass",
        "GrassGPT Humanizer", "Quantum Lawn Learner", "Sod Sentience", "AI Grasspocalypse", "Grass Overlord vFinal"

    };

    public static double[] grassNeeded = {
        9e12, 9e13, 9e15, 9e17, 9e19,
        9e22, 9e25, 9e28, 9e31, 9e35,
        9e39, 9e43, 9e47, 9e51, 9e55
    };

    public static int index;


    void Start()
    {
        upgrade = SaveManager.Instance.gameData.gptUpgrade;
        index = SaveManager.Instance.gameData.gptIndex;
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

