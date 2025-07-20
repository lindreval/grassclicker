using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public List<Achievements> achievements;
    private DateTime lastResetDate;

    private void Start()
    {
        LoadQuestProgress();
    }

    public void UpdateQuestProgress(string achievementName, int amount)
    {
        var achievement = achievements.Find(q => q.achievementName == achievementName);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.currentAmount += amount;
            if (achievement.currentAmount >= achievement.requiredAmount)
            {
                achievement.isCompleted = true;
                achievement.currentAmount = achievement.requiredAmount;
            }
            SaveQuestProgress();
        }
    }

    public void SaveQuestProgress()
    {
        foreach (var achievement in achievements)
        {
            PlayerPrefs.SetInt(achievement.achievementName + "_CurrentAmount", achievement.currentAmount);
            PlayerPrefs.SetInt(achievement.achievementName + "_IsCompleted", achievement.isCompleted ? 1 : 0);
            PlayerPrefs.SetInt(achievement.achievementName + "_RewardClaimed", achievement.rewardClaimed ? 1 : 0);
        }
    }

    private void LoadQuestProgress()
    {
        foreach (var achievement in achievements)
        {
            achievement.currentAmount = PlayerPrefs.GetInt(achievement.achievementName + "_CurrentAmount", 0);
            achievement.isCompleted = PlayerPrefs.GetInt(achievement.achievementName + "_IsCompleted", 0) == 1;
            achievement.rewardClaimed = PlayerPrefs.GetInt(achievement.achievementName + "_RewardClaimed", 0) == 1;
        }
    }
}