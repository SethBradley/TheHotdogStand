using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    public static GameController instance;


    
    public List<Interactable> exits;
    

    void Awake()
    {
        instance = this;



    }
}

