using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        float saleModifier = SaveData.current.saleModifier;
        float patienceModifier = SaveData.current.patienceModifier;

        SalesWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>().value = SaveData.current.upgradeData[0];
        PatienceWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>().value = SaveData.current.upgradeData[1];
    
        SalesWindow.transform.Find("DescriptionText").GetComponent<TMP_Text>().text = $"Price Markup: {saleModifier}x";
        SalesWindow.transform.Find("DescriptionText").GetComponent<TMP_Text>().text = $"Patience: {patienceModifier} seconds";
    }

    public void LevelUpSales()
    {
        var upgradeLevel = SalesWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>();
        if (upgradeLevel.value <= 8)
        {
            SaveData.current.upgradeData[0] ++;
            SaveData.current.saleModifier += 0.15f;
            UpdateUpgradeUI();
        }
    }
    public void LevelUpPatience()
    {
        var upgradeLevel = PatienceWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>();
        if (upgradeLevel.value <= 8)
        {
            SaveData.current.upgradeData[1] ++;
            SaveData.current.patienceModifier += 0.4f;
            UpdateUpgradeUI();
        }
    }
}
