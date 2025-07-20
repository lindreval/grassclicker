using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomEvent : MonoBehaviour
{
    public GameObject statusScreen;
    public TextMeshProUGUI statusText;
    public GameObject goldenSun;


    public static double eventMultplier;

    public static int cashChange;

    [Range(0f, 1f)]
    public float disasterProbability = 1f;

    public float checkInterval = 10f;    

    void Start()
    {
        statusScreen.SetActive(false);
        goldenSun.SetActive(false);
        InvokeRepeating(nameof(CheckForEvent), checkInterval, checkInterval);
    }

    
    public void boxToggle(){
        statusScreen.SetActive(!statusScreen.activeSelf);
    }

    private void CheckForEvent()
    {
        if (UnityEngine.Random.value < disasterProbability)
        {
            if(UnityEngine.Random.value < 0.5f)
            {
                Storm();
            } 
            else{
                GoldenSun();
            }
        }
    }

    public void GoldenSun()
    {
        goldenSun.SetActive(true);
        float screenWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float screenHeight = Camera.main.orthographicSize;

        // Generate random X and Y coordinates within the screen bounds
        float randomX = UnityEngine.Random.Range(-screenWidth, screenWidth);
        float randomY = UnityEngine.Random.Range(-screenHeight, screenHeight);

        // Set the sprite's position to the random coordinates
        goldenSun.transform.position = new Vector3(randomX, randomY, 0);
    }

    public void Storm()
    {
        boxToggle();
        eventMultplier = 0.5;
        StartCoroutine(Wait());
    }

    public void chooseReward(){
        if(UnityEngine.Random.value < 0.5f)
            {
                randomUpgrade();
            } 
            else{
                randomMultiplier();
            }
        goldenSun.SetActive(false);
    }

    public void randomUpgrade()
    {
        cashChange = (int)Math.Round(GlobalCount.allTimeCount * 0.25);
        GlobalCount.currentTotal += cashChange;
        goldenSun.SetActive(false);
    }

    public void randomMultiplier()
    {
        boxToggle();
        statusText.text = "The Sun is shining brightly\nx2 multiplier for 30 seconds";
        eventMultplier = 2;
        goldenSun.SetActive(false);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(30);
        eventMultplier = 1;
        boxToggle();
    }
}
