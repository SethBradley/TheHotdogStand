using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public Camera mainCam;
    public LayerMask playerInteractableMask;

    //UI Touching
    PointerEventData _pointerData;
    public GraphicRaycaster[]  _raycaster;
    EventSystem _eventSystem;

    StandInteractable touchedInteractable;

    //Inventories
    public Dictionary<Ingredient, int> _bunInventory;
    public Dictionary<Ingredient, int> _hotdogInventory;
    public bool windowOpened;


    
    private void Start()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;


    
    
    _bunInventory = new Dictionary<Ingredient, int>();
    _hotdogInventory = new Dictionary<Ingredient, int>();
    _bunInventory.Add(DatabaseMaster.instance.GetIngredient("bun_001"), 5);  
    
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


    public void AddBuns(Ingredient type, int amount)
    {

    }
}
