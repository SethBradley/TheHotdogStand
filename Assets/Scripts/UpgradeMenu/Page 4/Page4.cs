using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Page4 : MonoBehaviour
{
    public List<GameObject> achievementWindowList;
    public List<bool> achivementUnlockedStatus;
    private RewardsHandler rewardsHandler;

    Page2 page2Handler;
    Page3 page3Handler;


    private void Awake() 
    {
        rewardsHandler = GetComponent<RewardsHandler>();
        page2Handler = GetComponent<Page2>();
        page3Handler = GetComponent<Page3>();
        LoadAchievementDataToList();
        EnableRewardButtonsAndBadges();
    }

    void LoadAchievementDataToList()
    {
        Debug.Log("Loading AchievementData");
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
                Debug.Log(window.gameObject.name + " has been unlocked. Setting Emblem");
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
            x++;
        }
    }

    public void FindAndGiveReward(GameObject achievementWindow)
    {
        foreach (GameObject entry in achievementWindowList)
        {
            if (achievementWindow == entry)
            {
                rewardsHandler.GiveReward(achievementWindowList.IndexOf(entry));
                entry.transform.Find("Labe_Large_Orange").Find("Achievement_RewardButton").gameObject.SetActive(false);
                entry.transform.Find("Labe_Large_Orange").Find("Achievement_Badge").gameObject.SetActive(true);
            }
        }
        page2Handler.unlockIngredientsTier2();
        page2Handler.unlockIngredientsTier3();
        page3Handler.LoadUpgradeData();
        
        
        GetComponent<UpgradeMenuHandler>().UpdateMoney();
    }




}
