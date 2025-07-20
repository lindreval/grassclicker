using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class CallingQuest : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public TextMeshProUGUI progressText;
    public Button button;
    public Button button2;
    public Slider progressSlider;
    public DailyQuest quest;
    public DailyQuestManager questManager;

    void Update()
    {
        CheckForReward();
        Progress();
    }

    private void CheckForReward()
    {
        questText.text = quest.description;
        button.interactable = quest.isCompleted && !quest.rewardClaimed;
        if (quest.videoWatched)
        {
            button2.gameObject.SetActive(false);
            button.gameObject.SetActive(false);
        }
        else if (quest.rewardClaimed)
        {
            button.gameObject.SetActive(false);
            button2.gameObject.SetActive(true);
        }
        else
        {
            button.gameObject.SetActive(true);
            button2.gameObject.SetActive(false);
        }
    }

    private void Progress()
    {
        progressText.text = quest.currentAmount + "/" + quest.requiredAmount;

        float fraction = (float)quest.currentAmount / (float)quest.requiredAmount;
        progressSlider.value = Mathf.Clamp01(fraction);
    }

    public void GiveReward()
    {
        GlobalCount.currentTotal += quest.rewardAmount;

        if (quest.rewardClaimed)
        {
            quest.videoWatched = true;
        }
        else
        {
            quest.rewardClaimed = true;
        }
        questManager.SaveQuestProgress();
    }
}
