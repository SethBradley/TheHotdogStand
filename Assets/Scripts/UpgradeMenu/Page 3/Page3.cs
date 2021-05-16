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
    public GameObject MayoUpgradeButton;
    public GameObject KetchupUpgradeButton;
    public GameObject MustardUpgradeButton;

    Slider salesSlider;
    Slider patienceSlider;

    float salesUpgradeCost;

    private void Awake() 
    {
        salesSlider = SalesWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>();
        patienceSlider = PatienceWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>();
        LoadUpgradeData();

        
                
    }

    public void UnlockUpgrades()
    {
        SalesWindow.transform.Find("LockedPanel").gameObject.SetActive(false);
        PatienceWindow.transform.Find("LockedPanel").gameObject.SetActive(false);
    }

    public void LoadUpgradeData()
    {
        /*if (SaveData.current.achievementRewardClaimedArray[1] == false)
        {
            return;
        }*/

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
        GetComponent<UpgradeMenuHandler>().UpdateMoney();


        float saleModifier = SaveData.current.saleModifier;
        float patienceModifier = SaveData.current.patienceModifier;

        SalesWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>().value = SaveData.current.upgradeData[0];
        PatienceWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>().value = SaveData.current.upgradeData[1];
    
        SalesWindow.transform.Find("DescriptionText").GetComponent<TMP_Text>().text = $"Price Markup: {saleModifier}x";
        PatienceWindow.transform.Find("DescriptionText").GetComponent<TMP_Text>().text = $"Patience: {patienceModifier} seconds";

        if (salesSlider.value > 0)
        {
            SalesWindow.transform.Find("NextUpgradeText_Price").GetComponent<TMP_Text>().text = $"${((salesSlider.value + 10) * 1.15f).ToString("F2")}";
        }
        if (patienceSlider.value > 0)
        {
            PatienceWindow.transform.Find("NextUpgradeText_Price").GetComponent<TMP_Text>().text = $"${((patienceSlider.value + 10) * 1.15f).ToString("F2")}";
        }
    
    }

    public void LevelUpSales()
    {
        Slider salesSlider = SalesWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>();
        salesUpgradeCost = (salesSlider.value + 10) * 1.15f;

        if (salesSlider.value == 0
            && SaveData.current.totalMoney >= 10f)
        {
            SaveData.current.upgradeData[0] ++;
            SaveData.current.saleModifier += 0.15f;
            SaveData.current.totalMoney -= 10f;
            UpdateUpgradeUI();
            return;
        }

        if (salesSlider.value <= 8
            && SaveData.current.totalMoney >= salesUpgradeCost)
        {
            SaveData.current.upgradeData[0] ++;
            SaveData.current.saleModifier += 0.15f;
            SaveData.current.totalMoney -= salesUpgradeCost;
            UpdateUpgradeUI();
        }
    }
    public void LevelUpPatience()
    {
        var patienceSlider = PatienceWindow.transform.Find("Slider_Token_Fillamount").GetComponent<Slider>();
        float upgradeCost = (patienceSlider.value + 10) * 1.15f;

        if (patienceSlider.value == 0
            && SaveData.current.totalMoney >= 10f)
        {
            SaveData.current.upgradeData[0] ++;
            SaveData.current.patienceModifier += 0.15f;
            UpdateUpgradeUI();
            SaveData.current.totalMoney -= 10f;
            return;
        }
        
        if (patienceSlider.value <= 8
            && SaveData.current.totalMoney >= upgradeCost)
        {
            SaveData.current.upgradeData[1] ++;
            SaveData.current.patienceModifier += 0.4f;
            SaveData.current.totalMoney -= upgradeCost;
            UpdateUpgradeUI();
        }
    }

    public void UnlockSpicyMayo()
    {
        if (SaveData.current.achievementRewardClaimedArray[4] == false)
        {
            return;
        }

        GetComponent<UpgradeMenuHandler>().tier2Mayo.discovered = true;
    }
    public void UnlockDuckfatKetchup()
    {
        if (SaveData.current.achievementRewardClaimedArray[5] == false)
        {
            return;
        }

        GetComponent<UpgradeMenuHandler>().tier2Ketchup.discovered = true;
    }
    public void UnlockDijonMustard()
    {
        if (SaveData.current.achievementRewardClaimedArray[6] == false)
        {
            return;
        }

        GetComponent<UpgradeMenuHandler>().tier2Mustard.discovered = true;
    }
}
