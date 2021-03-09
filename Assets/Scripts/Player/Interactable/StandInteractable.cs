using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandInteractable : MonoBehaviour
{
    public StandInteractableData standInteractabledata;
    public InteractionComponent interactionComponent;
    public static Action<InteractionComponent, bool> InteractableToggle;
    
    

    private void Start() 
    {
        interactionComponent = standInteractabledata._interactionComponent;
    }

    public bool OnSelected()
    {
        if (standInteractabledata.interactableOpensWindow)
        {
            InteractableToggle(interactionComponent,  true);
            //Debug.Log("You selected " + interactionComponent + ". Opening window");
            return true;
        }
        
        Debug.Log("You selected " + interactionComponent);
        return false;
    }

    public void OnDeselected()
    {
        InteractableToggle(interactionComponent,  false);
    }

}
