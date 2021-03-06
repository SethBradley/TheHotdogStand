using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SitAtBus : IState
{
    private Interactable target;
    private Pedestrian pedestrian;
    private NavMeshAgent agent;
    private Animator anim;

    public SitAtBus(Interactable _target, Pedestrian _pedestrian, NavMeshAgent _agent, Animator _anim)
    {
        target = _target;
        pedestrian = _pedestrian;
        agent = _agent;
        anim = _anim;
    }
    public void OnEnter()
    {
        //agent.isStopped = true;
        Debug.Log("Beginning to wait at bus");
        anim.SetBool("Sit", true);
        OrientToSeat();
        

    }

    public void Tick()
    {
        Debug.Log("Waiting at bus");
       
        
    }

    public void OnExit()
    {
        Debug.Log("Exiting wait at bus");
        pedestrian._target.isOccupied = false;
    }

    void OrientToSeat()
    {
        Vector3 newRotation = pedestrian._target.interaction.orientation;
        Vector3 newPosition = pedestrian.transform.position + pedestrian._target.interaction.sitPosition;

        //Debug.Log(newRotation);
        pedestrian.transform.position = newPosition;
        pedestrian.transform.localRotation = Quaternion.Euler(newRotation);
        // Debug.Log(pedestrian.transform.rotation);

    }


}
