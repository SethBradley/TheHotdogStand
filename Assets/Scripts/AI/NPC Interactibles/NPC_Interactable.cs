using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPC_InteractableType
{
    EXIT, BUS_STOP_SEAT, CUSTOMER
}

[CreateAssetMenu(fileName = "NPCInteractable", menuName = "ScriptableObjects/NPCInteractable", order = 0)]
public class NPC_Interactable : ScriptableObject 
{
    public NPC_InteractableType interactionType;



    
}
