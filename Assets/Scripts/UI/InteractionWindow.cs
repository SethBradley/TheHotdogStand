using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionWindow : MonoBehaviour
{
    public GameObject ingredientSlot;

    public InteractionComponent interactionComponent;

    public Dictionary<Ingredient, int> inventory;

    private void OnEnable()
    {
        interactionComponent = transform.parent.GetComponent<UIController>().interactionComponent;
        InitializeInteractionWindow();
    }
    
    private void InitializeInteractionWindow() 
    {
        if (interactionComponent == InteractionComponent.BUNS)
        {
            inventory = PlayerController.instance._bunInventory;
        }


        foreach (var entry in inventory)
        {
            if (transform.childCount > inventory.Count)
            {
                foreach (Transform child in transform)
                {
                    Destroy(child.gameObject);
                }
            }
            
            else if (transform.childCount < inventory.Count)
            {
            GameObject newIngredientSlot = Instantiate(ingredientSlot, parent:this.transform) as GameObject;
            newIngredientSlot.GetComponent<IngredientSlot>().ingredient = entry.Key;
            newIngredientSlot.GetComponent<IngredientSlot>().amount = entry.Value;
            }

            else if (transform.childCount == inventory.Count)
            {
                foreach (Transform child in transform)
                {
                    IngredientSlot IngredientSlotConfig =  child.GetComponent<IngredientSlot>();
                    
                        IngredientSlotConfig.UpdateSlot(entry.Key, entry.Value);
                        continue;
                }
            }
        }    
    }

    private void OnDisable() 
    {

    }


}
