using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotdogHolderWindow : MonoBehaviour
{
    public GameObject hotdogSlot;
    private void OnEnable() 
    {
        

        foreach (var entry in PlayerController.instance._hotdogInventory)
        {
            GameObject newHotdogSlot = Instantiate(hotdogSlot, parent:this.transform) as GameObject;
            newHotdogSlot.GetComponent<BunSlot>().ingredient = entry.Key;
            newHotdogSlot.GetComponent<BunSlot>().amount = entry.Value;
            
        }    
    }
}
