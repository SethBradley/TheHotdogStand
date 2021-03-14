using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : IState
{
    Interactable target;
    IState newState = null;

    Interactable interactible;
    protected Pedestrian pedestrian;
    protected NavMeshAgent agent;
    protected Animator anim;

    public MoveToTarget(Interactable _target, Pedestrian _pedestrian, NavMeshAgent _agent, Animator _anim)
    {
        target = _target;
        pedestrian = _pedestrian;
        agent = _agent;
        anim = _anim;
    }
    public void OnEnter()
    {
//        Debug.Log("Entering Move to Target");

        anim.SetBool("Walking", true);
        agent.SetDestination(target.transform.position);
    }


    public void Tick()
    {
//        Debug.Log("Moving to Target");

        

        if (pedestrian._target != target)
        {
            Debug.Log("Target changed, setting new destination");
            target = pedestrian._target.GetComponent<Interactable>();
            Debug.Log(target);
            agent.SetDestination(target.transform.position);
            return;
        }
        

        if (pedestrian._agent.remainingDistance <= 0.5)
        {
            if (target.interaction.interactionType == 0)
            {
                Object.Destroy(pedestrian.gameObject);
                return;
            }
            
            pedestrian.changeState = true;
            Debug.Log("Changed Pedestrian changeState to true");
        }
        
    }

    public void OnExit()
    {
       // Debug.Log("exiting move to Target");
        anim.SetBool("Walking", false);
        agent.enabled = false;
    }


}
