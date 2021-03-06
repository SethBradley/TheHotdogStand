using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Pedestrian : MonoBehaviour
{
    public Interactable _target;
    public NavMeshAgent _agent;
    public List<GameObject> _checkedTargets;
    public Animator _anim;

    [NonSerialized]
    public bool changeState;

    public Dictionary<NPC_InteractableType, IState> newStateDict;
    
    StateMachine stateMachine;



    void Start()
    {
        stateMachine = new StateMachine();
        newStateDict = new Dictionary<NPC_InteractableType, IState>();

        _target = GetRandomExit();
        _agent = this.GetComponent<NavMeshAgent>();
        _anim = this.GetComponent<Animator>();
        _checkedTargets = new List<GameObject>();

        


        IState moveToTarget = new MoveToTarget(_target, this, _agent, _anim);
        IState sitAtBus = new SitAtBus(_target, this, _agent, _anim);



        newStateDict.Add(NPC_InteractableType.BUS_STOP_SEAT, sitAtBus);


        stateMachine.newState = moveToTarget;
    }

    void Update()
    {
        stateMachine.Tick();

        SearchForNewTarget();

        SetNewState();
        
    }

    //Put this inside StateMachine
    private void SetNewState()
    {
        if (changeState)
        {
            changeState = false;

            foreach (var entry in newStateDict)
            {
               if (entry.Key.Equals(_target.interaction.interactionType))
               {
                   stateMachine.newState = entry.Value;
               }              
            }
        }

        return;
        
    }

    public Interactable GetRandomExit()
    {
        int random = UnityEngine.Random.Range(0, GameController.instance.exits.Count);
        Interactable newTarget = GameController.instance.exits[random];
        
        return newTarget;
    }

    void SearchForNewTarget()
    {

        Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, 3.0f);

        foreach (Collider obj in nearbyTargets)
        {
            if (obj.tag == "Target")
            {
                int random = UnityEngine.Random.Range(0,10);
                if (random >= 1 && !_checkedTargets.Contains(obj.gameObject))
                {
                    _target = obj.GetComponent<Interactable>();
                    _target.isOccupied = true;
                }
                else if (random < 1 && !_checkedTargets.Contains(obj.gameObject))
                {
                    _checkedTargets.Add(obj.gameObject);
                }
                
            }
        }
    }

    
    
}
