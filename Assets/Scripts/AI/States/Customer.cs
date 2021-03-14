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

    
    
    public Customer(Interactable _target, Pedestrian _pedestrian, NavMeshAgent _agent, Animator _anim, GameObject _patienceMeter)
    {
        target = _target;
        pedestrian = _pedestrian;
        agent = _agent;
        anim = _anim;
        patienceMeter = _patienceMeter.GetComponent<PatienceMeter>();
    }


    public void OnEnter()
    {
        anim.SetBool("Walking", false);
        

        startRotation = pedestrian.transform.rotation.eulerAngles;
        newRotation = pedestrian._target.rotation;

        startPosition = pedestrian.transform.position;
        newPosition = pedestrian._target.position;

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
                GenerateCustomerOrder();
                pedestrian.gameObject.layer = 9;
                patienceMeter = GameObject.Instantiate(patienceMeter, parent: pedestrian.transform);
                return;
            }
            return;
        }

        //Debug.Log("Put out order");        
        
        if (patienceMeter == null)
        {
            Debug.Log ("Customer ran out of patience and left");
            pedestrian._target = pedestrian.GetRandomExit();
            
            pedestrian.changeState = true;
            
        }

    }

    public void OnExit()
    {
        Debug.Log("Exiting Customer state");
        agent.enabled = true;
        pedestrian.gameObject.layer = 0;
    }




    void OrientToStand()
    {   
        pedestrian.transform.rotation = Quaternion.Euler(SethUtils.PhysicsTools.ProperLerpRotation(startRotation, newRotation, x));

        if (x >= 2)
        {   
            playAnimation = false;
        }
    
        //Debug.Log(x);
        x += Time.deltaTime * 2f;        
    }

    void GenerateCustomerOrder()
    {
        customerOrder = new List<Ingredient>();

        float chanceForHotdog = SethUtils.MathTools.RandomNumberGeneration(0f,1f);
        bool addedHotdog;

        float chanceForCondiments = SethUtils.MathTools.RandomNumberGeneration(0f,1f);

        

        if (chanceForHotdog >= 0.25f)
        {
            customerOrder.Add(AddHotdogToOrder());
            customerOrder.Add(AddBunToOrder());
            addedHotdog = true;

            if (chanceForCondiments >= 0.25f && addedHotdog)
            {
                customerOrder.Add(AddCondimentsToOrder(chanceForCondiments));
            }        
        }

        foreach (var item in customerOrder)
            Debug.Log(item);
    }

    Ingredient AddHotdogToOrder()
    {
        List<Ingredient> hotdogOptions = new List<Ingredient>();

        foreach (Ingredient ingredient in DatabaseMaster.instance.ingredientDatabase.hotdogDatabase)
        {
            if (ingredient.discovered)
            {
                hotdogOptions.Add(ingredient);
            }
        }
        return hotdogOptions[SethUtils.MathTools.RandomNumberGeneration(0, hotdogOptions.Count)];
    }
    Ingredient AddBunToOrder()
    {
        List<Ingredient> bunOptions = new List<Ingredient>();

        foreach (Ingredient ingredient in DatabaseMaster.instance.ingredientDatabase.bunDatabase)
        {
            if (ingredient.discovered)
            {
                bunOptions.Add(ingredient);
            }
        }
        return bunOptions[SethUtils.MathTools.RandomNumberGeneration(0, bunOptions.Count)];
    }

    //Condiments NEEDS TO BE REWORKED YUCK
    Ingredient AddCondimentsToOrder(float chanceForCondiments)
    {
//Adding Mayo
        if (chanceForCondiments >= 0.90)
        {
            return DatabaseMaster.instance.GetIngredient("con_001");
        }
        if (chanceForCondiments >= 0.80)
        {
            customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_002"));
            return DatabaseMaster.instance.GetIngredient("con_001");
            
        }
        if (chanceForCondiments >= 0.70)
        {
            customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_003"));
            return DatabaseMaster.instance.GetIngredient("con_001");
        }

//Adding Ketchup
        if (chanceForCondiments >= 0.60)
        {
            return DatabaseMaster.instance.GetIngredient("con_002");
        }
        if (chanceForCondiments >= 0.50)
        {
            customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_001"));
            return DatabaseMaster.instance.GetIngredient("con_002");
        }
        if (chanceForCondiments >= 0.40)
        {
            customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_003"));
            return DatabaseMaster.instance.GetIngredient("con_002");
        }
//Adding Mustard
        if (chanceForCondiments >= 0.30)
        {
            return DatabaseMaster.instance.GetIngredient("con_003");
        }
        if (chanceForCondiments >= 0.20)
        {
            customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_001"));
            return DatabaseMaster.instance.GetIngredient("con_003");
        }
        if (chanceForCondiments >= 0.10)
        {
            customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_002"));
            return DatabaseMaster.instance.GetIngredient("con_003");
        }

        return DatabaseMaster.instance.GetIngredient("con_003");
    }



}
