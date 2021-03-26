using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{

    public IState currentState;
    public IState newState;

    public void Tick()
    {
        if (newState != null)
        {
            currentState?.OnExit();

            currentState = newState;
            newState = null;

            currentState.OnEnter();
        
            return;
        }

        currentState?.Tick();
    }

}
