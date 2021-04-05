using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryEntry
{
    public Ingredient ingredient;
    public int amount;
}

[CreateAssetMenu(fileName = "Inventory", menuName = "TheHotdogStand/Inventory")]
public class Inventory : ScriptableObject 
{
    public ingredientType type;

    public List<InventoryEntry> inventoryList;

    
}