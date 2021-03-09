using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "IngredientDatabase", menuName = "Databases/IngredientDatabase")]
public class IngredientDatabase : ScriptableObject 
{
    public List<Ingredient> allIngredients;
    public List<Ingredient> bunDatabase;
    public List<Ingredient> hotdogDatabase;

    
}
