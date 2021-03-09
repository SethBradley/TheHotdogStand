using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject interactionWindow;
    public InteractionComponent interactionComponent;
        void Start()
    {
        StandInteractable.InteractableToggle += ToggleInteractionWindow;
    }

    void ToggleInteractionWindow(InteractionComponent _interactionComponent,  bool _boolean)
    {
        interactionComponent = _interactionComponent;
        transform.Find("InteractionWindow").transform.gameObject.SetActive(_boolean);
    }



    void SetActiveObjectAndChildren(Transform parent, bool boolean)
    {
                
        foreach (Transform child in parent)
        {
            child.gameObject.SetActive(boolean);
            if (child.childCount > 1)
            {
                SetActiveObjectAndChildren(child, boolean);
            }
        }
        parent.gameObject.SetActive(boolean);
    }


}
