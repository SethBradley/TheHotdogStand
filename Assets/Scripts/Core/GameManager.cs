using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int selectedSaveSlot;

    public PlayerProfile playerProfile; 
  

    private void Start()
    {
        if (instance != null && instance != this)
            Destroy(this.gameObject);
        else 
            instance = this;


        //InitializeGameData(); to check if save exists and if so set dataSlots   
    }
}
