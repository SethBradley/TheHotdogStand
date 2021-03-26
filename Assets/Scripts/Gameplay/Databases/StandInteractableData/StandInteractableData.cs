using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionComponent
{
    BUNS, HOTDOGS,
    MAYO, MUSTARD, KETCHUP,
    DRINKS, 
    CUSTOMER = 10
}

[CreateAssetMenu(fileName = "StandInteractable", menuName = "TheHotdogStand/StandInteractable")]
public class StandInteractableData : ScriptableObject 
{
    public InteractionComponent _interactionComponent;
    public bool interactableOpensWindow;
    
}