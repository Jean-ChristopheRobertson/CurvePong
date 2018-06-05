using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


public class AchievementManager : MonoBehaviour
{
    private Dictionary<AchievementType, List<Achievement>> achievements;
    private Dictionary<AchievementType, int> achievementKeeper;
    public Dictionary<string, string> achievedText;

    public static AchievementManager Instance = null;



    void Awake()
    {
        Debug.Log("awake called");

        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        achievedText = new Dictionary<string, string>();
        achievementKeeper = new Dictionary<AchievementType, int>();

        foreach (AchievementType i in Enum.GetValues(typeof(AchievementType)))
        {
            achievementKeeper.Add(i, 0);
        }
        
        
        achievements = new Dictionary<AchievementType, List<Achievement>>();

        var listStart = new List<Achievement>();
        listStart.Add(new Achievement() { countToUnlock = 1, isUnlocked = false, Message = "First Time Playing!", txtobjName = "ach1" });
        listStart.Add(new Achievement() { countToUnlock = 10, isUnlocked = false, Message = "Experienced Ponger", txtobjName = "ach2" });
        listStart.Add(new Achievement() { countToUnlock = 50, isUnlocked = false, Message = "Pong Veteran", txtobjName = "ach3" });
        

        var listWin = new List<Achievement>();
        listWin.Add(new Achievement() {countToUnlock = 1, isUnlocked = false, Message = "First Win", txtobjName = "ach4" });
        listWin.Add(new Achievement() { countToUnlock = 10, isUnlocked = false, Message = "Wins for days", txtobjName = "ach5" });
        listWin.Add(new Achievement() { countToUnlock = 25, isUnlocked = false, Message = "Winner Winner Chicken Dinner", txtobjName = "ach6" });

        var listScore = new List<Achievement>();
        listScore.Add(new Achievement() { countToUnlock = 100, isUnlocked = false, Message = "100 Goals!", txtobjName = "ach7" });
        listScore.Add(new Achievement() { countToUnlock = 9000, isUnlocked = false, Message = "Over 9000!", txtobjName = "ach8" });


        achievements.Add(AchievementType.starts, listStart);
        achievements.Add(AchievementType.Wins, listWin);
        achievements.Add(AchievementType.Score, listScore);
    }
    


    void RaiseAchievementUnlocked(Achievement ach)
    {
        // unlock the event
        ach.isUnlocked = true;
        Debug.Log(achievedText);
        achievedText.Add(ach.Message,ach.txtobjName);
        Debug.Log(ach.Message);

    }


    public void RegisterEvent(AchievementType type)
    {
        if (!achievementKeeper.ContainsKey(type))
        {
            Debug.Log("no event registered");
            return;
        }

        achievementKeeper[type]++;
        Debug.Log("event registered");
        ParseAchievements(type);
    }

    public void ParseAchievements(AchievementType type)
    {
        foreach (var kvp in achievements.Where(a => a.Key == type))
        {
            foreach (var ach in kvp.Value.Where(a => a.isUnlocked == false))
            {
                if (type == AchievementType.Score)
                {
                    if (achievementKeeper[type] >= ach.countToUnlock)
                        RaiseAchievementUnlocked(ach);
                }
                else if (achievementKeeper[type] == ach.countToUnlock)
                {
                    RaiseAchievementUnlocked(ach);
                }
            }
        }
    }
}