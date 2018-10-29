using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected bool forward = true;
    protected GameObject character;
    protected StateMachine controller;

    public bool Forward
    {
        get
        {
            return forward;
        }

        set
        {
            forward = value;
        }
    }

    public State(StateMachine controller, GameObject character)
    {
        this.character = character;
        this.controller = controller;
    }


    public abstract void Execute();
}
