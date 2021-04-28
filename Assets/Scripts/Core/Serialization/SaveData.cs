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
    public List<int> count_playerInventory = new List<int>();

    public bool[] achievementArray = new bool[9];
    public bool[] achievementRewardClaimedArray = new bool[9];
    public int _totalCompletedOrders;
    public int _totalMayoOrders;
    public int _totalKetchupOrders;
    public int _totalMustardOrders;
    public List<int> upgradeData = new List<int>();
    public float saleModifier;
    public float patienceModifier;

}