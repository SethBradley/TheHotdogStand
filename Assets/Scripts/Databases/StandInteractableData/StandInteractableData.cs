using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionComponent
{
    BUNS, HOTDOGS, DRINKS, CUSTOMER
}

[CreateAssetMenu(fileName = "StandInteractable", menuName = "TheHotdogStand/StandInteractable")]
public class PlayerInteractable : ScriptableObject 
{
    public InteractionComponent interactionComponent;
    
}