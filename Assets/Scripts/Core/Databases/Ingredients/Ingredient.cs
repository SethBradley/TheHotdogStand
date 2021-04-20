using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public enum ingredientType
{
    BUN, HOTDOG, CONDIMENT, DRINK, SNACK 
}
[System.Serializable]
[CreateAssetMenu(fileName = "Ingredient", menuName = "TheHotdogStand/Ingredient")]

public class Ingredient : ScriptableObject 
{
    public string ingredientID;
    public ingredientType ingredientType;
    
    public string ingredientName;
    public Sprite sprite;


    [TextArea(3,10)]
    public string description;

    public float sellValue;

    public float buyValue;

    public bool discovered;

    public string unlockRequirement;
    
    
}