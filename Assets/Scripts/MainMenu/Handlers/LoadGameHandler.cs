using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameHandler : MonoBehaviour
{
    int selectedSaveSlot;
    public void ClickLoadGameSlot(int saveSlot) => VerifyExistingData(saveSlot);
    


    void VerifyExistingData(int saveSlot)
    {
        selectedSaveSlot = saveSlot;  
        
        if (SerializationManager.VerifyExistingData(selectedSaveSlot))
        {
            LoadGameData();
            return;
        }
        Debug.Log("No Game Data found, display load denied window");
    }


    void LoadGameData()
    {
        string path = Application.persistentDataPath + "/saves/" + selectedSaveSlot + ".save";

        GameManager.instance.selectedSaveSlot = selectedSaveSlot;
        GameManager.instance.selectedSaveData = SerializationManager.Load(path) as SaveData;
        Debug.Log(GameManager.instance.selectedSaveData.profile.money);
    }

}
