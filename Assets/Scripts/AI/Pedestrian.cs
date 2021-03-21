using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using SethUtils;


public class Pedestrian : MonoBehaviour
{
    public Interactable _target;
    public Interactable _exitTarget;
    public NavMeshAgent _agent;
    public List<GameObject> _checkedTargets;
    public List<Ingredient> _customerOrder;
    public Animator _anim;
    public GameObject _patienceMeter;
    public GameObject orderBubble;

    

    public bool changeState;
    public bool searchForTarget = true;
    public bool newCustomer;

    public Dictionary<NPC_InteractableType, IState> newStateDict;
    
    StateMachine stateMachine;

    



    void Start()
    {
        stateMachine = new StateMachine();
        newStateDict = new Dictionary<NPC_InteractableType, IState>();

        _target = GetRandomExit();
        _exitTarget = _target;
        _agent = this.GetComponent<NavMeshAgent>();
        _anim = this.GetComponent<Animator>();
        _checkedTargets = new List<GameObject>();
        _customerOrder = new List<Ingredient>();


        IState moveToTarget = new MoveToTarget(_target, this, _agent, _anim);
        IState sitAtBus = new SitAtBus(_target, this, _agent, _anim);
        IState customer = new Customer(_target, this, _agent, _anim, _patienceMeter);


        newStateDict.Add(NPC_InteractableType.BUS_STOP_SEAT, sitAtBus);
        newStateDict.Add(NPC_InteractableType.CUSTOMER, customer);
        newStateDict.Add(NPC_InteractableType.EXIT, moveToTarget);


        stateMachine.newState = moveToTarget;
    }

    void Update()
    {
        stateMachine.Tick();

        if (searchForTarget)
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


    //Spawning Methods
    public void PedestrianRespawn()
    {        
        PedestrianSpawnController.instance.CycleNPC(this);
    }

    void SearchForNewTarget()
    {     
        Collider[] nearbyTargets = Physics.OverlapSphere(transform.position, 3.0f);

        foreach (Collider obj in nearbyTargets)
        {
            if (obj.tag == "Target")
            {
                int random = UnityEngine.Random.Range(0,10);
                if (random >= 1 && !_checkedTargets.Contains(obj.gameObject) && obj.GetComponent<Interactable>().occupant == null)
                {
                    _target = obj.GetComponent<Interactable>();
                    _target.occupant = this;
                    searchForTarget = false;
                    _checkedTargets.Add(obj.gameObject);
                    return;
                }
                else if (random < 1 && !_checkedTargets.Contains(obj.gameObject))
                {
                    _checkedTargets.Add(obj.gameObject);
                }
                
            }
        }
    
}
    //Custmer and Order Methods
    public void CreateOrderBubbleUI(List<Ingredient> order)
    {
        GameObject newOrderBubble = Instantiate(orderBubble, parent: this.transform) as GameObject;
        newOrderBubble.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 180f, -180f);
        //-0.04f, 1.5f, 0.17f
        for (int i = 0; i < _customerOrder.Count; i++)
        {
            newOrderBubble.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
            newOrderBubble.transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = _customerOrder[i].sprite;
        }
    }


        public void GenerateCustomerOrder()
    {
        _customerOrder = new List<Ingredient>();

        float chanceForHotdog = SethUtils.MathTools.RandomNumberGeneration(0f,1f);
        bool addedHotdog;

        float chanceForCondiments = SethUtils.MathTools.RandomNumberGeneration(0f,1f);

        

        if (chanceForHotdog >= 0.01f)
        {
            _customerOrder.Add(AddHotdogToOrder());
            _customerOrder.Add(AddBunToOrder());
            addedHotdog = true;

            if (chanceForCondiments >= 0.25f && addedHotdog)
            {
                _customerOrder.Add(AddCondimentsToOrder(chanceForCondiments));
            }
            CreateOrderBubbleUI(_customerOrder);  
        }

        foreach (var item in _customerOrder)
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
            _customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_002"));
            return DatabaseMaster.instance.GetIngredient("con_001");
            
        }
        if (chanceForCondiments >= 0.70)
        {
            _customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_003"));
            return DatabaseMaster.instance.GetIngredient("con_001");
        }

//Adding Ketchup
        if (chanceForCondiments >= 0.60)
        {
            return DatabaseMaster.instance.GetIngredient("con_002");
        }
        if (chanceForCondiments >= 0.50)
        {
            _customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_001"));
            return DatabaseMaster.instance.GetIngredient("con_002");
        }
        if (chanceForCondiments >= 0.40)
        {
            _customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_003"));
            return DatabaseMaster.instance.GetIngredient("con_002");
        }
//Adding Mustard
        if (chanceForCondiments >= 0.30)
        {
            return DatabaseMaster.instance.GetIngredient("con_003");
        }
        if (chanceForCondiments >= 0.20)
        {
            _customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_001"));
            return DatabaseMaster.instance.GetIngredient("con_003");
        }
        if (chanceForCondiments >= 0.10)
        {
            _customerOrder.Add(DatabaseMaster.instance.GetIngredient("con_002"));
            return DatabaseMaster.instance.GetIngredient("con_003");
        }

        return DatabaseMaster.instance.GetIngredient("con_003");
    }

    public void CustomerLeave()
    {
        changeState = true;
        var patienceMeter = transform.Find("PatienceCanvas(Clone)");
        var orderBubble = transform.Find("OrderBubble 1(Clone)");
        _target = GetRandomExit();
        SethUtils.TransformTools.SetActiveObjectAndChildren(orderBubble, false);
        
        if (patienceMeter != null)
            SethUtils.TransformTools.SetActiveObjectAndChildren(patienceMeter, false);
        
        
    }

}
