using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private State patrolState1;
    private State idleState;
    private State arrestState;
    GameObject character;
    State currentState;

    public State PatrolState1
    {
        get
        {
            return patrolState1;
        }
    }

    public State IdleState
    {
        get
        {
            return idleState;
        }
    }

    public State ArrestState
    {
        get
        {
            return arrestState;
        }
    }

    void Start()
    {
        character = this.gameObject;
        patrolState1 = new PatrolState1(this, character);
        arrestState = new ArrestState(this, character);
        idleState = new IdleState(this, character);
        currentState = PatrolState1;
    }

    void Update()
    {
        currentState.Execute();
    }

    public void changeState(State newState)
    {
        currentState = newState;
    }
}
