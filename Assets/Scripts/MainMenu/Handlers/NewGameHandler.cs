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
        SerializationManager.Save($"SaveDataSlot_{selectedSaveSlot}", newSaveData);
        GameManager.instance.selectedSaveSlot = selectedSaveSlot;
    }
}
