using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianOrder : MonoBehaviour
{
    public List<Ingredient> _order;


    public List<Ingredient> GenerateOrder()
    {
        List<Ingredient> availableIngredients = new List<Ingredient>();

        foreach (var ingredientInventory in GameController.instance._inventoryHolder.ingredientInventories)
        {
            foreach (var inventoryList in ingredientInventory.inventoryList)
            {
                availableIngredients.Add(inventoryList.ingredient);
                Debug.Log("AHHHH");
            }
        }
        return availableIngredients;
    }
}
