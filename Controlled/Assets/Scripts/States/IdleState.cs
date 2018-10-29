using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    int count = 0;
    public IdleState(StateMachine controller, GameObject character) : base(controller, character)
    {

    }

    public override void Execute()
    {
        if(count%300 == 0)
        {
            controller.changeState(controller.PatrolState1);
        }

        character.GetComponent<Animator>().SetBool("Move", false);
        count++;
    }
}

