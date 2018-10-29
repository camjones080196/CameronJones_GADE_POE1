using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrestState : State
{
    int count = 0;
    public ArrestState(StateMachine controller, GameObject character) : base(controller, character)
    {

    }

    public override void Execute()
    {
        character.GetComponent<Animator>().SetBool("Move", false);
    }
}
