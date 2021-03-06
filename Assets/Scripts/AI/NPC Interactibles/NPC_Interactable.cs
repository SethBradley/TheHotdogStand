using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NPC_InteractableType
{
    EXIT, BUS_STOP_SEAT
}

[CreateAssetMenu(fileName = "NPCInteractable", menuName = "ScriptableObjects/NPCInteractable", order = 0)]
public class NPC_Interactable : ScriptableObject 
{
    public NPC_InteractableType interactionType;

    public Vector3 orientation;



    
}
