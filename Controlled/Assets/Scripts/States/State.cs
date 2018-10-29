using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected GameObject character;
    protected StateMachine controller;

    public State(StateMachine controller, GameObject character)
    {
        this.character = character;
        this.controller = controller;
    }

    public abstract void Execute();
}
