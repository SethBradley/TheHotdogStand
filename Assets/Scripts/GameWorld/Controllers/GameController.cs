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
    

    void Awake()
    {
        instance = this;
        
    }
    
    private void Start() {
        StartDay();
    }


    public void StartDay()
    {
        GetInventoryCountForEachItem();
    }

    public void EndDay()
    {
        PlayerController.instance.gameObject.SetActive(false);
        sceneTransitionWindow.SetActive(true);
        SavePlayerData();
    }


    public void SavePlayerData()
    {

        SaveData.current.totalMoney += PlayerController.instance.dailyEarnings;
    }

    private void GetInventoryCountForEachItem()
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

    }

}




