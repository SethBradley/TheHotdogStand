using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    
    public GameObject orderEntrySlot;
    public GameObject interactionWindow;
    public GameObject currentOrderWindow;
    public GameObject orderUpWindow;
    [HideInInspector]
    public InteractionComponent interactionComponent;
        void Start()
    {
        StandInteractable.InteractableToggle += ToggleInteractionWindow;
        PlayerController.AddToOrderSlotUI += AddToOrderUI;
        PlayerController.ClearOrderSlots += CloseOrderWindow;
    }

    void ToggleInteractionWindow(InteractionComponent _interactionComponent,  bool _boolean)
    {
        interactionComponent = _interactionComponent;
        interactionWindow.SetActive(_boolean);
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
        var nextOrderSlot = currentOrderWindow.transform.GetChild(PlayerController.instance.currentOrder.Count - 1);
        
        nextOrderSlot.gameObject.SetActive(true);
        nextOrderSlot.GetComponent<OrderEntrySlot>().ingredientInSlot = _ingredient;
        nextOrderSlot.GetComponent<OrderEntrySlot>().sprite = _ingredient.sprite;
        nextOrderSlot.GetComponent<Image>().sprite = _ingredient.sprite;
    }

    public void CloseOrderWindow()
    {
        //var currentOrderWindow = transform.Find("CurrentOrderWindow");
        //var orderUpWindow = transform.Find("OrderupWindow");

        if (currentOrderWindow.gameObject.activeSelf)
        {
            currentOrderWindow.gameObject.SetActive(false);
            orderUpWindow.gameObject.SetActive(false);
        }
    }
    
    private void OnDisable() 
    {
        StandInteractable.InteractableToggle -= ToggleInteractionWindow;
        PlayerController.AddToOrderSlotUI -= AddToOrderUI;
        PlayerController.ClearOrderSlots -= CloseOrderWindow;

    }


}
