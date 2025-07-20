using UnityEngine;

[CreateAssetMenu(fileName = "New Achievement", menuName = "Achievment")]
public class Achievements : ScriptableObject
{
    public string achievementName;
    public string description;
    public int requiredAmount;
    public int currentAmount;
    public bool isCompleted;
    public bool rewardClaimed;
    public double rewardAmount;
    
}
