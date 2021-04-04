using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWindow : MonoBehaviour
{

    public InteractionComponent interactionComponent;

    private void OnEnable()
    {
        
        interactionComponent = transform.parent.GetComponent<UIController>().interactionComponent;
        InitializeInteractionWindow(interactionComponent);
    }
    
    private void InitializeInteractionWindow(InteractionComponent _interactionComponent) 
    {
        var selectedInventory = GameController.instance._inventoryHolder.GetIngredientInventory(_interactionComponent);
        int x = 0;

        if (selectedInventory.inventoryList.Count == 0)
        {
            Debug.Log("Empty inventory display out of INTERACTIONCOMPONENT");
            return;
        }
        
        foreach (var entry in selectedInventory.inventoryList)
        {
            transform.GetChild(x).gameObject.SetActive(true);
            transform.GetChild(x).GetComponent<IngredientSlot>().UpdateSlot(entry.ingredient, entry.amount);
            transform.GetChild(x).GetComponent<IngredientSlot>().OnCloseInteractionWindow += CloseInteractionWindow;
            x++;
        }    
        x = 0;
    }

    public void CloseInteractionWindow()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<IngredientSlot>().OnCloseInteractionWindow -= CloseInteractionWindow;
        }

        gameObject.SetActive(false);

    }

    private void OnDisable() 
    {

    }


}
