using UnityEngine;

[CreateAssetMenu(fileName = "New Daily Quest", menuName = "Daily Quest")]
public class DailyQuest : ScriptableObject
{
    public string questName;
    public string description;
    public int requiredAmount;
    public int currentAmount;
    public bool isCompleted;
}
