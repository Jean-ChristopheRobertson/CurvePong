using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{
    public int countToUnlock { get; set; }
    public bool isUnlocked { get; set; }
    public string Message { get; set; }
    public string txtobjName { get; set; }
}

public enum AchievementType
{
    Score,
    Wins,
    starts
};
