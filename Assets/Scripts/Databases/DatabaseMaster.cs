using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseMaster : MonoBehaviour
{
    public static DatabaseMaster instance;
    public IngredientDatabase ingredientDatabase;
    

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;
    }

    public Ingredient GetIngredient(string id)
    {
        foreach (var entry in ingredientDatabase.ingredientDatabase)
        {
            if (entry.ingredientID == id)
            {
                return entry;
            }
        }
        return null;
    }
}
