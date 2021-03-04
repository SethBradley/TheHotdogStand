using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    public static GameController instance;


    
    public List<Transform> waypoints;
    

    void Awake()
    {
        instance = this;



    }
}

