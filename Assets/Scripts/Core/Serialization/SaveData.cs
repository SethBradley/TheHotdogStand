using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveData
{
    public int saveSlotNumber;
    private static SaveData _current;
    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }
            return _current;
        }
        set
        {
            _current = value;
        }
    }

    //public PlayerProfile profile;
    public int saveSlot;
    public string savePath;
    public float totalMoney;
    public int currentDay;
    public List<UnityEngine.Object> Keys_playerInventory = new List<UnityEngine.Object>();
    public List<int> Values_playerInventory = new List<int>();
    //public Dictionary<UnityEngine.Object, int> playerInventory;

    //Public ScriptableObj Inventory?
    //Public ScriptableObj Upgrades?
    //Public ScriptableObj Achievements?


    /*public void OnBeforeSerialize()
    {
        Keys_playerInventory.Clear();
        Values_playerInventory.Clear();
        
        foreach (var entry in playerInventory)
        {
            Keys_playerInventory.Add(entry.Key);
            Values_playerInventory.Add(entry.Value);
        }
    }

    public void OnAfterDeserialize()
    {
        playerInventory = new Dictionary<UnityEngine.Object, int>();

        for (int i = 0; i != Math.Min(Keys_playerInventory.Count, Values_playerInventory.Count); i++)
            playerInventory.Add(Keys_playerInventory[i], Values_playerInventory[i]);        
    }*/
}