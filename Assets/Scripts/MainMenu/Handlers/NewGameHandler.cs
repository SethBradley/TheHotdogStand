using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameHandler : MonoBehaviour
{
    int selectedSaveSlot;

    public void ClickNewGameSlot1() => VerifyExistingData(1);
    
    public void ClickNewGameSlot2() => VerifyExistingData(2);
    
    public void ClickNewGameSlot3() => VerifyExistingData(3);
    
    void VerifyExistingData(int saveSlot)
    {
        selectedSaveSlot = saveSlot;  
        
        if (!SerializationManager.VerifyExistingData(selectedSaveSlot))
        {
            CreateNewSaveData();
            return;
        }
        Debug.Log("Save Data exists, want to over-write?");
        MainMenuController.instance.MainMenuUI.transform.Find("NewGameOverwriteWindow").gameObject.SetActive(true);
    }

    public void CreateNewSaveData()
    {
        Debug.Log("Creating new Save");

        SaveData newSaveData = new SaveData();

        newSaveData.upgradeData.Add(0);
        newSaveData.upgradeData.Add(0);
        newSaveData.saleModifier = 1f;
        newSaveData.patienceModifier = 1f;
        newSaveData._totalCompletedOrders = 100;


        newSaveData.count_playerInventory.Add(10);
        newSaveData.count_playerInventory.Add(0);
        newSaveData.count_playerInventory.Add(0);
        newSaveData.count_playerInventory.Add(10);
        newSaveData.count_playerInventory.Add(0);
        newSaveData.count_playerInventory.Add(0);
        newSaveData.saveSlotNumber = selectedSaveSlot;
        

        SerializationManager.CreateNewSave($"SaveDataSlot_{selectedSaveSlot}", newSaveData);
        GameManager.instance.selectedSaveSlot = selectedSaveSlot;
        GameManager.instance.selectedSaveData = newSaveData;
    }
}
