using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RandomEvent : MonoBehaviour
{

    public List<GameObject> weather = new List<GameObject>();
    public GameObject goldenSun;


    public static double eventMultplier;

    public static int cashChange;

    [Range(0f, 1f)]
    public float disasterProbability = 1f;

    public float checkInterval = 10f;    

    void Start()
    {
        foreach (var GameObject in weather)
        {
            GameObject.SetActive(false);
        }
        goldenSun.SetActive(false);
        InvokeRepeating(nameof(CheckForEvent), checkInterval, checkInterval);
    }

    private void CheckForEvent()
    {
        if (UnityEngine.Random.value < disasterProbability)
        {
            if(UnityEngine.Random.value > 0.5f)
            {
                Rain();
            } 
            else if(UnityEngine.Random.value > 0.25f){
                GoldenSun();
            }else
            {
                Storm();
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
        weather[1].SetActive(true);
        eventMultplier = 0.5;
        FadeText.Instance.ShowMessage("A storm is washing away your grass! -50% grass production for 30 seconds");

        StartCoroutine(Wait());
        weather[1].SetActive(false);
    }
    
    public void Rain()
    {
        weather[2].SetActive(true);
        eventMultplier = 1.5;
        FadeText.Instance.ShowMessage("Rain is quenching your grass! +50% grass production for 60 seconds");

        StartCoroutine(Wait());
        weather[2].SetActive(false);
    }

    public void Sunny()
    {
        weather[0].SetActive(true);

        FadeText.Instance.ShowMessage("The Sun is shining brightly\nx2 multiplier for 30 seconds");
        eventMultplier = 2;
        goldenSun.SetActive(false);

        StartCoroutine(Wait());

        weather[0].SetActive(false);
    }

    public void chooseReward()
    {
        if (UnityEngine.Random.value < 0.5f)
        {
            randomUpgrade();
        }
        else
        {
            Sunny();
        }
        goldenSun.SetActive(false);
    }

    public void randomUpgrade()
    {
        cashChange = (int)Math.Round(GlobalCount.allTimeCount * 0.25);
        GlobalCount.currentTotal += cashChange;
        goldenSun.SetActive(false);
    }

    

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(30);
        eventMultplier = 1;
    }
}
