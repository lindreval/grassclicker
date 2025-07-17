using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class CallingQuest : MonoBehaviour
{
    public TextMeshProUGUI questText;
    public Button button;
    public DailyQuest quest;

    void Update()
    {
        CheckForReward();
        ProgressText();
    }

    private void CheckForReward()
    {
        button.interactable = quest.isCompleted;
    }

    private void ProgressText()
    {
        questText.text = quest.currentAmount + "/" + quest.requiredAmount;
    }

    public void GiveReward()
    {
        GlobalCount.currentTotal += 10;
    }
}
