using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    public static GameController instance;


    
    public List<Interactable> exits;
    public List<GameObject> HotdogStandSpots;
    

    void Awake()
    {
        instance = this;



    }
}

