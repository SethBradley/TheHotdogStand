using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SethUtils;
public class Customer : IState
{
    private Interactable target;
    private Pedestrian pedestrian;
    private NavMeshAgent agent;
    private Animator anim;
    private PatienceMeter patienceMeter;

    public List<Ingredient> customerOrder;

    float x = 0f;
    float findOrderTimer;
    bool playAnimation = true;


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

        patienceMeter = pedestrian._patienceMeter.GetComponent<PatienceMeter>();
        findOrderTimer = SethUtils.MathTools.RandomNumberGeneration(2f, 5f);
        //Debug.Log(findOrderTimer);
    }

    public void Tick()
    {
        if (playAnimation)
            OrientToStand();

        if (findOrderTimer >= 0)
        {
            findOrderTimer -= Time.deltaTime;
            if (findOrderTimer <= 0)
            {
                Debug.Log ("Generating order");
                pedestrian.GenerateCustomerOrder();
                
                return;
            }
            return;
        }        
    }

    public void OnExit()
    {
        Debug.Log("Exiting Customer state");

        target.occupant = null;
        pedestrian.searchForTarget = true;
        agent.enabled = true;
        pedestrian.gameObject.layer = 0;
        playAnimation = true;
        
    }





    void OrientToStand()
    {   
        pedestrian.transform.rotation = Quaternion.Euler(SethUtils.PhysicsTools.ProperLerpRotation(startRotation, newRotation, x));
        pedestrian.transform.position = SethUtils.PhysicsTools.ProperLerpRotation(startPosition, newPosition, x);

        if (x >= 2)
        {   
            playAnimation = false;
        }
    
        //Debug.Log(x);
        x += Time.deltaTime * 2f;        
    }




}
