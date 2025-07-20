using System;
using System.Collections.Generic;
using UnityEngine;

public class DailyQuestManager : MonoBehaviour
{
    public List<DailyQuest> dailyQuests;
    private DateTime lastResetDate;

    private void Start()
    {
        LoadQuestProgress();
        CheckDailyReset();
    }

    private void CheckDailyReset()
    {
        string savedDate = PlayerPrefs.GetString("LastQuestReset", "");
        if (DateTime.TryParse(savedDate, out lastResetDate))
        {
            if (lastResetDate.Date != DateTime.Now.Date)
            {
                ResetQuests();
            }
        }
        else
        {
            ResetQuests();
        }
    }

    public void ResetQuests()
    {
        foreach (var quest in dailyQuests)
        {
            quest.currentAmount = 0;
            quest.isCompleted = false;
            quest.rewardClaimed = false;
            quest.videoWatched = false;
        }

        lastResetDate = DateTime.Now;
        PlayerPrefs.SetString("LastQuestReset", lastResetDate.ToString());
        SaveQuestProgress();
    }

    public void UpdateQuestProgress(string questName, int amount)
    {
        var quest = dailyQuests.Find(q => q.questName == questName);
        if (quest != null && !quest.isCompleted)
        {
            quest.currentAmount += amount;
            if (quest.currentAmount >= quest.requiredAmount)
            {
                quest.isCompleted = true;
                quest.currentAmount = quest.requiredAmount;
            }
            SaveQuestProgress();
        }
    }

    public void SaveQuestProgress()
    {
        foreach (var quest in dailyQuests)
        {
            PlayerPrefs.SetInt(quest.questName + "_CurrentAmount", quest.currentAmount);
            PlayerPrefs.SetInt(quest.questName + "_IsCompleted", quest.isCompleted ? 1 : 0);
            PlayerPrefs.SetInt(quest.questName + "_RewardClaimed", quest.rewardClaimed ? 1 : 0);
        }
    }

    private void LoadQuestProgress()
    {
        foreach (var quest in dailyQuests)
        {
            quest.currentAmount = PlayerPrefs.GetInt(quest.questName + "_CurrentAmount", 0);
            quest.isCompleted = PlayerPrefs.GetInt(quest.questName + "_IsCompleted", 0) == 1;
            quest.rewardClaimed = PlayerPrefs.GetInt(quest.questName + "_RewardClaimed", 0) == 1;
        }
    }
}
