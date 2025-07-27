using UnityEngine;
using System;
using TMPro;

public class OfflineEarningsManager : MonoBehaviour
{
    public GameObject popupUI; // Optional: assign a popup UI
    public TextMeshProUGUI popupText;
    public double maxSecondsAway;
    private double earnings;



    void Start()
    {
        CalculateOfflineEarnings();
        maxSecondsAway = SaveManager.Instance.gameData.maxTimeAway;
    }

    void OnApplicationQuit()
    {
        SaveLogoutTime();
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveLogoutTime();
        }
    }

    void SaveLogoutTime()
    {
        PlayerPrefs.SetString("LastPlayedTime", DateTime.Now.ToBinary().ToString());
        PlayerPrefs.Save();

    }

    void CalculateOfflineEarnings()
    {
        if (!PlayerPrefs.HasKey("LastPlayedTime"))
            return;

        long temp = Convert.ToInt64(PlayerPrefs.GetString("LastPlayedTime"));
        DateTime lastTime = DateTime.FromBinary(temp);
        TimeSpan timeAway = DateTime.Now - lastTime;

        double secondsAway = Mathf.Min((float)timeAway.TotalSeconds, (float)maxSecondsAway);

        earnings = AutoClicker.countIncrease * secondsAway;
        
        

        if (earnings > 0)
        {
            if (popupUI != null && popupText != null)
            {
                popupUI.SetActive(true);
                popupText.text = $"While you were away, you earned {earnings:F0} grass!";
            }

            Debug.Log($"Offline for {timeAway.TotalSeconds:F0} seconds. Earned {earnings:F0} grass.");
        }
    }

    public void GiveTimes1()
    {
        GlobalCount.currentTotal += earnings;
        popupUI.SetActive(false);
        FadeText.Instance.ShowMessage("+" + earnings);
    }

    public void GiveTimes2()
    {
        GlobalCount.currentTotal += earnings * 2;
        popupUI.SetActive(false);
        FadeText.Instance.ShowMessage("+" + earnings*2);
    }
    
}
