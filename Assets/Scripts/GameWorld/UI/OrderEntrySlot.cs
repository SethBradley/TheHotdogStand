using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderEntrySlot : MonoBehaviour
{
    public Ingredient ingredientInSlot;
    public Sprite sprite;

    private void OnDisable() 
    {
        ingredientInSlot = null;
        sprite = null;
        GetComponent<Image>().sprite = null;
        gameObject.SetActive(false);
    }
    

    void UpdateOrderEntrySlot(Ingredient _ingredient)
    {
        if (ingredientInSlot == null)
        {
            ingredientInSlot = _ingredient;
            sprite = _ingredient.sprite;

            GetComponent<Image>().sprite = sprite;
        }
    }

}
