using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotdogSlot : MonoBehaviour
{
    public Ingredient ingredient;
    public int amount;
    public Sprite image;




    public void BunSlotClicked()
    {
        Debug.Log("This slot contains: " + ingredient.ingredientName + " and you have this amount left: " + amount);

    }

}
