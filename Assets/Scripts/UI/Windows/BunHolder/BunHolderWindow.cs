using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunHolderWindow : MonoBehaviour
{
    public GameObject bunSlot;
    public EventHandler<BunSlot> OnUpdateSlot;
    
    private void OnEnable() 
    {
        var bunInventory = PlayerController.instance._bunInventory;
        foreach (var entry in bunInventory)
        {
            if (transform.childCount > bunInventory.Count)
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
            }
            
            else if (transform.childCount < bunInventory.Count)
            {
            GameObject newBunSlot = Instantiate(bunSlot, parent:this.transform) as GameObject;
            newBunSlot.GetComponent<BunSlot>().ingredient = entry.Key;
            newBunSlot.GetComponent<BunSlot>().amount = entry.Value;
            }

            else if (transform.childCount == bunInventory.Count)
            {
                foreach (Transform child in transform)
                {
                    BunSlot bunSlotConfig =  child.GetComponent<BunSlot>();
                    
                        bunSlotConfig.UpdateSlot(entry.Key, entry.Value);
                        continue;
                }
            }
        }    
    }

    private void OnDisable() 
    {

    }


}
