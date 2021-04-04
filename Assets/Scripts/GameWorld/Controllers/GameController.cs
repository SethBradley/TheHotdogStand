using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject sceneTransitionWindow;
    public InventoryHolder _inventoryHolder;

    
    public List<Interactable> exits;
    public List<GameObject> HotdogStandSpots;
    public Dictionary<Ingredient,int> playerInventory;
    public float totalMoney;
    public int currentDay;
    
    [SerializeField] GameControllerUI gameControllerUI;

    void Awake()
    {
        instance = this;
        
    }
    
    private void Start() {
        StartDay();
    }


    public void StartDay()
    {
        playerInventory = GetInventoryCountForEachItem();
        gameControllerUI.TickNewDay(currentDay);
        
    }

    public void EndDay()
    {
        PlayerController.instance.gameObject.SetActive(false);
        sceneTransitionWindow.SetActive(true);
        totalMoney += PlayerController.instance.dailyEarnings;
        SavePlayerData();
    }


    public void SavePlayerData()
    {

        SaveData.current.totalMoney = totalMoney;
        CreateSaveDictionary(playerInventory);
    }

    private Dictionary<Ingredient,int> GetInventoryCountForEachItem()
    {
        Dictionary<Ingredient,int> NewDayInventoryCount = new Dictionary<Ingredient, int>();

        foreach (var entry in _inventoryHolder.ingredientInventories)
        {
            for (int i = 0; i < entry.inventoryList.Count; i++)
            {
                NewDayInventoryCount.Add(entry.inventoryList[i].ingredient, entry.inventoryList[i].amount);                
            }
            
        }

        foreach (var entry in NewDayInventoryCount)
        {
            Debug.Log("Ingredient: " + entry.Key);
            Debug.Log("Amount: " + entry.Value);

            
        }

        return NewDayInventoryCount;

        
    }

    private Dictionary<Object,int> CreateSaveDictionary(Dictionary<Ingredient,int> _inventory)
    {
        Dictionary<Object,int> inventoryToSave = new Dictionary<Object, int>();

        foreach (var entry in _inventory)
        {
            inventoryToSave.Add(entry.Key, entry.Value);            
        }

        return inventoryToSave;


        

    }



}




