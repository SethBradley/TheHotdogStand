using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "InventoryHolder", menuName = "TheHotdogStand/InventoryHolder")]
public class InventoryHolder : ScriptableObject
{
    public List<Inventory> ingredientInventories;
    



     public Inventory GetIngredientInventory(InteractionComponent _interactionComponent)
     {
         
         foreach (var entry in ingredientInventories)
         {
             if ((int)_interactionComponent == (int)entry.type)
             {
                 return entry;
             }
             continue;          
         }
         return null;

     }
}

