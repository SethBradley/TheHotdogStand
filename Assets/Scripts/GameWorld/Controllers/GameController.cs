using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject sceneTransitionWindow;


    
    public List<Interactable> exits;
    public List<GameObject> HotdogStandSpots;
    

    void Awake()
    {
        instance = this;
    }

    public void EndDay()
    {
        PlayerController.instance.gameObject.SetActive(false);
        sceneTransitionWindow.SetActive(true);
        SavePlayerProfile();
    }


    public void SavePlayerProfile()
    {
        GameManager.instance.playerProfile.money += PlayerController.instance.dailyEarnings;
        Debug.Log(GameManager.instance.playerProfile.money);
    }
}

