using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    //public PlayerProfile profile;
    public int saveSlot;
    public float totalMoney;

    //Public ScriptableObj Inventory?
    //Public ScriptableObj Upgrades?
    //Public ScriptableObj Achievements?

}