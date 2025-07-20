using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class CallingAchievements : MonoBehaviour
{
    public TextMeshProUGUI achievementText;
    public Button button;
    public Achievements achievement;
    public AchievementManager achievementManager;

    void Update()
    {
        CheckForReward();
        ProgressText();
    }

    private void CheckForReward()
    {
        button.interactable = achievement.isCompleted;
    }

    private void ProgressText()
    {
        achievementText.text = achievement.currentAmount + "/" + achievement.requiredAmount;
    }

    public void GiveRewardBy100()
    {
        GlobalCount.gemTotal += achievement.rewardAmount;
        achievement.requiredAmount *= 100;
        achievementManager.SaveQuestProgress();
    }

    public void GiveRewardBy10()
    {
        GlobalCount.gemTotal += achievement.rewardAmount;
        achievement.requiredAmount *= 10;
        achievementManager.SaveQuestProgress();
    }

    public void GiveRewardBy5()
    {
        GlobalCount.gemTotal += achievement.rewardAmount;
        achievement.requiredAmount *= 5;
        achievementManager.SaveQuestProgress();
    }

}
