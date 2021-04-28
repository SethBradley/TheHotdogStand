using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Page3 : MonoBehaviour
{
    public GameObject SalesWindow;
    public GameObject PatienceWindow;

    private void Awake() 
    {
        LoadUpgradeData();

        
                
    }

    public void UnlockUpgrades()
    {
        SalesWindow.transform.Find("LockedPanel").gameObject.SetActive(false);
        PatienceWindow.transform.Find("LockedPanel").gameObject.SetActive(false);
    }

    public void LoadUpgradeData()
    {
        if (SaveData.current.achievementRewardClaimedArray[1] == false)
        {
            return;
        }

        UnlockUpgrades();
        UpdateUpgradeUI();
    }

    public void SaveUpgradeData()
    {
        SaveData.current.upgradeData[0] = (int)SalesWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>().value;
        SaveData.current.upgradeData[1] = (int)PatienceWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>().value;
    }



    private void UpdateUpgradeUI()
    {
        SalesWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>().value = SaveData.current.upgradeData[0];
        PatienceWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>().value = SaveData.current.upgradeData[1];

    }
}
