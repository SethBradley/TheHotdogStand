using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IngredientSlot : MonoBehaviour
{
    public Ingredient ingredient;
    public int amount;
    public Sprite sprite;
    public Action OnCloseInteractionWindow;


    private void Awake() 
    {
         
    }
    





    public void SlotClicked()
    {
        var currentOrder = PlayerController.instance.currentOrder;
        

        if (!currentOrder.Contains(ingredient))
        {
            PlayerController.instance.AddToOrder(ingredient);
            PlayerController.instance.windowOpened = false;
            amount--;
            OnCloseInteractionWindow();
            //Debug.Log("This slot contains: " + ingredient.ingredientName + " and you have this amount left: " + amount);
            return;
        }

        //Error sound plays while making the ingredient in inventory flash red?
        return;
        

    }

    public void UpdateSlot(Ingredient _ingredient, int _amount)
    {
        if (ingredient == null)
        {
            ingredient = _ingredient;
            amount = _amount;
            sprite = _ingredient.sprite;
            GetComponent<Image>().sprite = _ingredient.sprite;
        }

        return;
    }


    

    private void OnDisable() 
    {
        gameObject.SetActive(false);
        ingredient = null;
        amount = 0;
        sprite = null;
    }

}
