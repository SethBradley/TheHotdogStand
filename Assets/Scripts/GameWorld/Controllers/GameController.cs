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
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;

        
        
    }
    
    private void Start() 
    {
        GameManager.instance.ChangeActiveScene();
        StartDay();
    }


    public void StartDay()
    {
        LoadPlayerInventory();
        currentDay = SaveData.current.currentDay;
        //playerInventory = GetInventoryCountForEachItem();
        gameControllerUI.TickNewDay(currentDay);   
    }

    [ContextMenu("End Day")]
    public void EndDay()
    {
        Debug.Log("Day is ending");
        currentDay++;
        totalMoney += PlayerController.instance.dailyEarnings;
        PlayerController.instance.gameObject.SetActive(false);
        sceneTransitionWindow.SetActive(true);
        
        SavePlayerData();
    }


    public void SavePlayerData()
    {

        SaveData.current.totalMoney += totalMoney;
        SaveData.current.currentDay = currentDay;
        SavePlayerInventory(GetInventoryCountForEachItem());
        StartCoroutine(WaitAndSave());
        AchievementManager.instance.SaveAchievementData();
        
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
            Debug.Log(entry);
        }
        
        return NewDayInventoryCount;

        
    }

    private void SavePlayerInventory(Dictionary<Ingredient,int> _inventory)
    {
        
        Dictionary<Ingredient,int> inventoryToSave = new Dictionary<Ingredient, int>();
        SaveData.current.count_playerInventory.Clear();
        foreach (var entry in _inventory)
        {
            SaveData.current.count_playerInventory.Add(entry.Value);
        }

                Debug.Log("Here is each entry in save data inventory");
        foreach (var entry in SaveData.current.count_playerInventory)
        {
            Debug.Log(entry);
        }
    }


    private void LoadPlayerInventory()
    {
        var saveDataCount = SaveData.current.count_playerInventory;

        
        
        foreach (var entry in _inventoryHolder.ingredientInventories)
        {
            for (int i = 0; i < entry.inventoryList.Count; i++)
            {
                Debug.Log("your original amount of "
                 + entry.inventoryList[i].ingredient.ingredientName +
                 " is " + entry.inventoryList[i].amount);
               
                entry.inventoryList[i].amount = SaveData.current.count_playerInventory[i];
                //SaveData.current.count_playerInventory.RemoveAt(i);
            
                Debug.Log("Loaded data, now your  "
                + entry.inventoryList[i].ingredient.ingredientName +
                " amount is " + entry.inventoryList[i].amount);
            
            }
        }
        

    }

    IEnumerator WaitAndSave()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("Game Saved");
        GameManager.instance.SaveGameData();
        GameManager.instance.GameWorldToUpgradeMenu();
    }

}




