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
    float x = 0f;
    Vector3 startRotation;
    Vector3 newRotation;
    Vector3 startPosition;
    Vector3 newPosition;
 

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
        

        startRotation = pedestrian.transform.rotation.eulerAngles;
        newRotation = pedestrian._target.interaction.orientation;

        startPosition = pedestrian.transform.position;
        newPosition = pedestrian._target.position;;

       
        
        

    }

    public void Tick()
    {
        Debug.Log("Waiting at bus");
        OrientToSeat();
       
        
    }

    public void OnExit()
    {
        Debug.Log("Exiting wait at bus");
        pedestrian._target.occupant = null;
    }

    void OrientToSeat()
    {
        
        Vector3 pedestrianLerpRotation = Vector3.Lerp(startRotation, newRotation, x);
        pedestrian.transform.rotation = Quaternion.Euler(pedestrianLerpRotation);
        
        Vector3 pedestrianLerpPosition = Vector3.Lerp(startPosition, newPosition, x);
        pedestrian.transform.position = pedestrianLerpPosition;

        x += Time.deltaTime * 1.2f;
    }


}
