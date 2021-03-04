using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : IState
{
    Transform target;
    protected Pedestrian pedestrian;
    protected NavMeshAgent agent;

    public MoveToTarget(Transform _target, Pedestrian _pedestrian, NavMeshAgent _agent)
    {
        target = _target;
        pedestrian = _pedestrian;
        agent = _agent;
    }
    public void OnEnter()
    {
        Debug.Log("Entering Move to exit");
        agent.SetDestination(target.position);
    }


    public void Tick()
    {
        Debug.Log("Moving to exit");

        if (pedestrian._target != target)
        {
            Debug.Log("Target changed, setting new destination");
            target = pedestrian._target;
            agent.SetDestination(target.position);
        }
        

        if (pedestrian._agent.remainingDistance <= 1)
        {
            if (target.tag.Contains("Exit"))
            {
                Object.Destroy(pedestrian.gameObject);
            }

        }
        
    }

    public void OnExit()
    {
        Debug.Log("exiting move to exit");
    }


}
