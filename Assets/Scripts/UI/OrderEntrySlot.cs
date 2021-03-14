using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderEntrySlot : MonoBehaviour
{
    public Ingredient ingredientInSlot;
    public Sprite sprite;
    

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
