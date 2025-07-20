using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpinWheel : MonoBehaviour
{
    public RectTransform wheel;
    public Button button;
    public int numberOfSegments = 8;   
    public float spinDuration = 4f;
    public float maxSpinSpeed = 1000f;

    private bool isSpinning = false;
    private float spinTime = 0f;
    private float currentSpeed = 0f;
    private float targetAngle;

    public DailyQuestManager questManager;
    public AchievementManager achievementManager;

    public DailyQuest quest;


    public void Spin()
    {
        if (isSpinning) return;

        int randomSegment = Random.Range(0, numberOfSegments);
        float degreesPerSegment = 360f / numberOfSegments;

        // Add multiple full spins (like 3 full rotations) + target angle
        targetAngle = 360f * 5 + (randomSegment * degreesPerSegment);

        isSpinning = true;
        spinTime = 0f;
        currentSpeed = maxSpinSpeed;
    }

    void Update()
    {
        UpdateSpin();
        UpdateButton();
    }

    private void UpdateButton()
    {
        button.interactable = !quest.isCompleted;
        if (!quest.isCompleted)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Spin";
        } else {
            button.GetComponentInChildren<TextMeshProUGUI>().text = "Already Spun";
        }
    }

    private void UpdateSpin()
    {
        if (!isSpinning) return;

        spinTime += Time.deltaTime;

        float t = spinTime / spinDuration;
        float smoothT = Mathf.SmoothStep(0f, 1f, t);

        float currentAngle = Mathf.Lerp(0, targetAngle, smoothT);
        wheel.rotation = Quaternion.Euler(0, 0, -currentAngle);

        if (t >= 1f)
        {
            isSpinning = false;
            int finalSegment = Mathf.FloorToInt((360f - (targetAngle % 360f)) / (360f / numberOfSegments)) % numberOfSegments;
            Debug.Log("Landed on segment: " + finalSegment);
            GiveReward(finalSegment);
        }
    }

    private void GiveReward(int segment)
    {
        switch (segment)
        {
            case 0:
                GlobalCount.currentTotal += 100;
                break;
            case 1:
                GlobalCount.currentTotal += 100 * AutoClicker.countIncrease;
                break;
            case 2:
                GlobalCount.currentTotal += 100 * AutoClicker.countIncrease;
                break;
            case 3:
                GlobalCount.currentTotal += 100 * AutoClicker.countIncrease;
                break;
            case 4:
                GlobalCount.currentTotal += 100 * AutoClicker.countIncrease;
                break;
            case 5:
                GlobalCount.currentTotal += 100 * AutoClicker.countIncrease;
                break;
            case 6:
                GlobalCount.currentTotal += 100 * AutoClicker.countIncrease;
                break;
            case 7:
                GlobalCount.currentTotal += 100 * AutoClicker.countIncrease;
                break;
        }

        questManager.UpdateQuestProgress("SpinQuest", 1);
        achievementManager.UpdateQuestProgress("SpinQuest", 1);
    }
}
