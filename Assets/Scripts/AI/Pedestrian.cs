using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Pedestrian : MonoBehaviour
{
    public Transform _target;
    public NavMeshAgent _agent;
    public List<GameObject> _checkedTargets;
    
    StateMachine stateMachine;



    void Start()
    {
        _target = GetRandomTarget();
        _agent = this.GetComponent<NavMeshAgent>();

        _checkedTargets = new List<GameObject>();

        stateMachine = new StateMachine();


        IState moveToTarget = new MoveToTarget(_target, this, _agent);


        stateMachine.newState = moveToTarget;
    }

    void Update()
    {
        stateMachine.Tick();

        SearchForNewTarget();

        
    }

    


    public Transform GetRandomTarget()
    {
        int random = UnityEngine.Random.Range(0, GameController.instance.waypoints.Count);
        Transform newTarget = GameController.instance.waypoints[random];
        
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
                if (random >= 8 && !_checkedTargets.Contains(obj.gameObject))
                {
                    _target = obj.transform;
                }
                else if (random < 8 && !_checkedTargets.Contains(obj.gameObject))
                {
                    _checkedTargets.Add(obj.gameObject);
                }
                
            }
        }
    }

    
    
}
