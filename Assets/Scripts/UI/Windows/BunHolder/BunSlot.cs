using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BunSlot : MonoBehaviour
{
    public Ingredient ingredient;
    public int amount;
    public Sprite image;




    public void BunSlotClicked()
    {
        Debug.Log("This slot contains: " + ingredient.ingredientName + " and you have this amount left: " + amount);

    }

    public void UpdateSlot(Ingredient _ingredient, int _amount)
    {
        if (ingredient == null)
        {
            ingredient = _ingredient;
        }

        if (ingredient == _ingredient)
        {
            amount = _amount;
        }

        return;
    }

}
