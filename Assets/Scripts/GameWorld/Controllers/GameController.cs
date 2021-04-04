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
        currentDay = SaveData.current.currentDay;
        playerInventory = GetInventoryCountForEachItem();
        gameControllerUI.TickNewDay(currentDay);
        
        
    }

    [ContextMenu("End Day")]
    public void EndDay()
    {
        currentDay++;
        totalMoney += PlayerController.instance.dailyEarnings;
        PlayerController.instance.gameObject.SetActive(false);
        sceneTransitionWindow.SetActive(true);
        
        SavePlayerData();
    }


    public void SavePlayerData()
    {

        SaveData.current.totalMoney = totalMoney;
        SaveData.current.currentDay = currentDay;
        //ERRORSaveData.current.playerInventory = CreateSaveDictionary(playerInventory);
        GameManager.instance.SaveGameData();
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
        
        return NewDayInventoryCount;

        
    }

    private void CreateSaveDictionary(Dictionary<Ingredient,int> _inventory)
    {
        
        Dictionary<Ingredient,int> inventoryToSave = new Dictionary<Ingredient, int>();

        foreach (var entry in _inventory)
        {
            
            //ERRORinventoryToSave.Add(entry.Key as Object, entry.Value);     
        }


        foreach (var entry in inventoryToSave)
        {
            Debug.Log(entry);     
        }


        Debug.Log(inventoryToSave);

        //ERROR return inventoryToSave;


        

    }



}




