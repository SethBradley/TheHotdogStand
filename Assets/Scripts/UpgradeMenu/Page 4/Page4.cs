using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page4 : MonoBehaviour
{
    public List<GameObject> achievementWindowList;
    public List<bool> achivementUnlockedStatus;

    private void Awake() 
    {
        LoadAchievementDataToList();
        EnableRewardButtonsAndBadges();
    }

    void LoadAchievementDataToList()
    {
        var achievementDict = AchievementManager.instance.achievementDict;
        foreach (var entry in achievementDict)
        {
            achivementUnlockedStatus.Add(entry.Value);
        }
    }

    void EnableRewardButtonsAndBadges()
    {
        var achievementRewardClaimed = SaveData.current.achievementRewardClaimedArray;
        var achievementDict = AchievementManager.instance.achievementDict;
        int x = 0;

        foreach (GameObject window in achievementWindowList)
        {
            if (achivementUnlockedStatus[x])
            {
                if (!achievementRewardClaimed[x])
                {
                    window.transform.Find("Labe_Large_Orange").Find("Achievement_RewardButton").gameObject.SetActive(true);
                }
                else
                {
                    window.transform.Find("Labe_Large_Orange").Find("Achievement_Badge").gameObject.SetActive(true);
                    window.transform.Find("Labe_Large_Orange").GetComponent<Image>().color = Color.green;
                }
                x++;
                continue;
            }          
        }
    }





}
