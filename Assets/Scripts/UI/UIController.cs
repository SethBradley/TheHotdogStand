using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public GameObject orderEntrySlot;
    public InteractionComponent interactionComponent;
        void Start()
    {
        StandInteractable.InteractableToggle += ToggleInteractionWindow;
        PlayerController.AddToOrderSlotUI += AddToOrderUI;
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

    void AddToOrderUI(Ingredient _ingredient)
    {
        var currentOrderWindow = transform.Find("CurrentOrderWindow");
        var orderUpWindow = transform.Find("OrderupWindow");

        if (currentOrderWindow.gameObject.activeSelf == false)
        {
            currentOrderWindow.gameObject.SetActive(true);
            orderUpWindow.gameObject.SetActive(true);
            
        }
        //var orderEntrySlot = child.GetComponent<OrderEntrySlot>();
        Debug.Log(PlayerController.instance.currentOrder.Count - 1 + "AAAAAAAAA");
        var nextOrderSlot = currentOrderWindow.transform.GetChild(PlayerController.instance.currentOrder.Count - 1);
        
        nextOrderSlot.gameObject.SetActive(true);
        nextOrderSlot.GetComponent<OrderEntrySlot>().ingredientInSlot = _ingredient;
        nextOrderSlot.GetComponent<OrderEntrySlot>().sprite = _ingredient.sprite;
        nextOrderSlot.GetComponent<Image>().sprite = _ingredient.sprite;



    }
    


}
