using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //Save Data
    public float dailyEarnings;
   
    //
    public static PlayerController instance;
    public Camera mainCam;
    public LayerMask playerInteractableMask;

    //UI Touching
    PointerEventData _pointerData;
    public GraphicRaycaster[]  _raycaster;
    EventSystem _eventSystem;

    StandInteractable touchedInteractable;

    //Inventory
    
    public bool windowOpened;

    //Gameplay
    public List<Ingredient> currentOrder;

    //Delegates
    public static Action<Ingredient> AddToOrderSlotUI;
    public static Action<float> AddToDailyEarning;
    public static Action ClearOrderSlots;
    
    private void Start()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;   

        OrderUpWindow.OnAttemptToDeliver += DeliverOrder;


    }
    private void OnDisable() 
    {
        OrderUpWindow.OnAttemptToDeliver -= DeliverOrder;    
    }

    private void Update() 
    {
        //Convert to touch
        if (Input.GetMouseButtonDown(0))
        {
            if (windowOpened == false)
                CheckForInteraction();

            else
                TouchWhenWindowOpened();
        }
    }

    private void CheckForInteraction()
    {
        RaycastHit hit; 
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, playerInteractableMask))
        {
            touchedInteractable = hit.transform.GetComponent<StandInteractable>();

            if (touchedInteractable != null)
            {
                windowOpened = touchedInteractable.OnSelected();
                return;
            }
        }

    }

    void TouchWhenWindowOpened()
    {
        _pointerData = new PointerEventData(_eventSystem);
        List<RaycastResult> results = new List<RaycastResult>();

        _pointerData.position = Input.mousePosition;
        foreach (var raycaster in _raycaster)
        {
            raycaster.Raycast(_pointerData, results);
        }
        if (results.Count == 0)
        {
            Debug.Log("Close window");
            windowOpened = false;
            touchedInteractable.OnDeselected();
        }
        
    }

//Order Methods

    public void AddToOrder(Ingredient ingredient)
    {
        if (!currentOrder.Contains(ingredient))
        {
            currentOrder.Add(ingredient);
            RemoveFromInventory(ingredient);
            Debug.Log("The ingredient youre going to add to UI now is " + ingredient.ingredientName);
            AddToOrderSlotUI(ingredient);
            return;
        }
        
        Debug.Log("Already in order"); 
    }

    public void ClearOrder()
    {
        currentOrder.Clear();
        ClearOrderSlots();
    }


    public void DeliverOrder()
    {
        RaycastHit hit; 
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000f, playerInteractableMask))
        {
            var customer = hit.transform;
            var customerOrder = customer.GetComponent<Pedestrian>()._customerOrder;
            float costOfOrder = 0;

            if (customer.GetComponent<StandInteractable>().interactionComponent == InteractionComponent.CUSTOMER)
            {
                foreach (var item in currentOrder)
                {
                    CheckCondimentForAchievement(item);

                    if (!customerOrder.Contains(item))
                    {
                        Debug.Log("Incorrect order");
                        return;
                    }
                    else if (customerOrder.Count != currentOrder.Count)
                    {
                        return;
                    }

                    costOfOrder += item.sellValue;
                    costOfOrder *= SaveData.current.saleModifier;
                    continue;
                }

                AddToDailyEarning(costOfOrder);
                dailyEarnings += costOfOrder;
                
                
                AchievementManager.totalCompletedOrders++;
                AchievementManager.instance.CheckAchievementEligbility();

                ClearOrder();
                customer.GetComponent<Pedestrian>().CustomerLeave();

                Debug.Log("Total Ketchup orders: " + AchievementManager.totalKetchupOrders);
            }
        }

        void CheckCondimentForAchievement(Ingredient _ingredient)
        {
            if (_ingredient.ingredientType != ingredientType.CONDIMENT)
                return;
            
            switch (_ingredient.ingredientName)
            {
                case "Mayo":
                    AchievementManager.totalMayoOrders++;
                    break;

                case "Ketchup":
                    AchievementManager.totalKetchupOrders++;
                    break;

                case "Mustard":
                    AchievementManager.totalMustardOrders++;
                    break;
                
                default:
                    break;
            }
        }
    }


//Inventory Methods
    public void RemoveFromInventory(Ingredient ingredient)
    {
        foreach (var entry in GameController.instance._inventoryHolder.ingredientInventories)
        {
            if (entry.type == ingredient.ingredientType)
            {
                for (int i = 0; i < entry.inventoryList.Count; i++)
                {
                    if (entry.inventoryList[i].ingredient == ingredient)
                    {
                        entry.inventoryList[i].amount--;
                        /*if (entry.inventoryList[i].amount.Equals(0))
                        {
                            entry.inventoryList.RemoveAt(i);
                        }*/
                    }
                }
            }
        }
    }


    // public void AddToInventory(Ingredient ingredient)
    // {
    //     foreach (var entry in _inventoryHolder.ingredientInventories)
    //     {
    //         if (entry.type == ingredient.ingredientType)
    //         {
    //             for (int i = 0; i < entry.inventoryList.Count; i++)
    //             {
    //                 if (entry.inventoryList[i].ingredient == ingredient)
    //                 {
    //                     entry.inventoryList[i].amount--;
    //                     if (entry.inventoryList[i].amount.Equals(0))
    //                     {
    //                         entry.inventoryList.RemoveAt(i);
    //                     }
    //                 }
    //             }
    //         }
    //     }
    // }
}
