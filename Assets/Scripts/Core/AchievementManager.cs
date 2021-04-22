using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AchievementManager : MonoBehaviour
{
    public static AchievementManager instance;
    public static int totalCompletedOrders;
    public static int totalMayoOrders;
    public static int totalKetchupOrders;
    public static int totalMustardOrders;
    public Dictionary<string,bool> achievementDict = new Dictionary<string, bool>();

    private void Awake() 
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else
        { 
            instance = this;
            achievementDict.Add("Your First Sale", false);
            achievementDict.Add("Dog Disher", false);
            achievementDict.Add("Dog Deliverer", false);
            achievementDict.Add("Dog Purveyor", false);
            achievementDict.Add("Thats...Interesting", false);
            achievementDict.Add("Seeing Red", false);
            achievementDict.Add("A Sharp Taste", false);
            achievementDict.Add("Condimental", false);
            achievementDict.Add("Completionist", false);


        }
    }

    public void LoadAchievementData()
    {
        achievementDict["Your First Sale"] = SaveData.current.achievementArray[0];
        achievementDict["Dog Disher"] = SaveData.current.achievementArray[1];
        achievementDict["Dog Deliverer"] = SaveData.current.achievementArray[2];
        achievementDict["Dog Purveyor"] = SaveData.current.achievementArray[3];
        achievementDict["Thats...Interesting"] = SaveData.current.achievementArray[4];
        achievementDict["Seeing Red"] = SaveData.current.achievementArray[5];
        achievementDict["A Sharp Taste"] = SaveData.current.achievementArray[6];
        achievementDict["Condimental"] = SaveData.current.achievementArray[7];
        achievementDict["Completionist"] = SaveData.current.achievementArray[8];
    
        totalCompletedOrders = SaveData.current._totalCompletedOrders;
        totalMayoOrders = SaveData.current._totalMayoOrders;
        totalKetchupOrders = SaveData.current._totalKetchupOrders;
        totalMustardOrders = SaveData.current._totalMustardOrders;
    }

    public void SaveAchievementData()
    {
        int x = 0;
        foreach (var entry in achievementDict)
        {
            SaveData.current.achievementArray[x] =entry.Value;
            x++;
        }
        x = 0;

        SaveData.current._totalCompletedOrders = totalCompletedOrders;
        SaveData.current._totalMayoOrders = totalMayoOrders;
        SaveData.current._totalKetchupOrders = totalKetchupOrders;
        SaveData.current._totalMustardOrders = totalMustardOrders;

    }

    public void CheckAchievementEligbility()
    {
        if (totalCompletedOrders >= 1
        && achievementDict["Your First Sale"] == false)
        {
            AchievementUnlock_YourFirstSale();
            Debug.Log("Achievement unlocked: " + achievementDict["Your First Sale"]);
        }
        if (totalCompletedOrders >= 20
        && achievementDict["Dog Disher"] == false)
        {
            AchievementUnlock_DogDisher();
        }
        if (totalCompletedOrders >= 50
        && achievementDict["Dog Deliverer"] == false)
        {
            AchievementUnlock_DogDeliverer();
        }
        if (totalCompletedOrders >= 100
        && achievementDict["Dog Purveyor"] == false)
        {
            AchievementUnlock_DogPurveyor();
        }
        if (totalMayoOrders >= 10
        && achievementDict["Thats...Interesting"] == false)
        {
            AchievementUnlock_ThatsInteresting();
        }
        if (totalKetchupOrders >= 10
        && achievementDict["Seeing Red"] == false)
        {
            AchievementUnlock_SeeingRed();
        }
        if (totalKetchupOrders >= 10
        && achievementDict["A Sharp Taste"] == false)
        {
            AchievementUnlock_aSharpTaste();
        }        


    }
    

    public void AchievementUnlock_YourFirstSale()
    {
        achievementDict["Your First Sale"] = true;
    }

    public void AchievementUnlock_DogDisher()
    {
        achievementDict["Dog Disher"] = true;
    }
        public void AchievementUnlock_DogDeliverer()
    {
        achievementDict["Dog Deliverer"] = true;
    }
        public void AchievementUnlock_DogPurveyor()
    {
        achievementDict["Dog Purveyor"] = true;
    }

    public void AchievementUnlock_ThatsInteresting()
    {
        achievementDict["Thats...Interesting"] = true;
    }

    public void AchievementUnlock_SeeingRed()
    {
        achievementDict["Seeing Red"] = true;
    }
    public void AchievementUnlock_aSharpTaste()
    {
        achievementDict["A Sharp Taste"] = true;
    }

    public void AchievementUnlock_Condimental()
    {
        achievementDict["Condimental"] = true;
    }

    public void AchievementUnlock_Completionist()
    {
        achievementDict["Completionist"] = true;
    }
}
