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
        
        if (interactionComponent == InteractionComponent.KETCHUP)
        {
            Debug.Log("You selected " + interactionComponent);
            PlayerController.instance.AddToOrder(DatabaseMaster.instance.GetIngredient("con_002"));
        }

        if (interactionComponent == InteractionComponent.MUSTARD)
        {
            PlayerController.instance.AddToOrder(DatabaseMaster.instance.GetIngredient("con_003"));
        }

        if (interactionComponent == InteractionComponent.MAYO)
        {
            PlayerController.instance.AddToOrder(DatabaseMaster.instance.GetIngredient("con_001"));
        }

        if (interactionComponent == InteractionComponent.CUSTOMER)
        {
            Debug.Log("Customer selected");
        }
        Debug.Log("You selected " + interactionComponent);
        return false;
    }

    public void OnDeselected()
    {
        InteractableToggle(interactionComponent,  false);
    }

}
