using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Customer : IState
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

    
    
    public Customer(Interactable _target, Pedestrian _pedestrian, NavMeshAgent _agent, Animator _anim)
    {
        target = _target;
        pedestrian = _pedestrian;
        agent = _agent;
        anim = _anim;
    }


    public void OnEnter()
    {
        anim.SetBool("Walking", false);
        

        startRotation = pedestrian.transform.rotation.eulerAngles;
        newRotation = pedestrian._target.rotation;

        startPosition = pedestrian.transform.position;
        newPosition = pedestrian._target.position;

        
    }

    public void Tick()
    {
        OrientToStand();
    }

    public void OnExit()
    {
        
    }


    void OrientToStand()
    {      

        float xLerp = Mathf.LerpAngle(startRotation.x, newRotation.x, x);
        float yLerp = Mathf.LerpAngle(startRotation.y, newRotation.y, x);
        float zLerp = Mathf.LerpAngle(startRotation.z, newRotation.z, x);
        Vector3 Lerped = new Vector3(xLerp, yLerp, zLerp);

        pedestrian.transform.rotation = Quaternion.Euler(Lerped);


        //Vector3 pedestrianLerpPosition = Vector3.Lerp(startPosition, newPosition, x);
        //pedestrian.transform.position = pedestrianLerpPosition;

        //Debug.Log(x);

        x += Time.deltaTime * 2f;
    }


}
