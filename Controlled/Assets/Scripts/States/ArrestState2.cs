using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrestState2 : State
{
    private Vector3 destination;

    public ArrestState2(StateMachine controller, GameObject character) : base(controller, character)
    {
        destination = GameObject.Find("ArrestTarget1").transform.position;
    }

    public override void Execute()
    {
        FlipCharacter();

        if (character.transform.position == GameObject.Find("ArrestTarget1").transform.position)
        {
            destination = GameObject.Find("ArrestTarget2").transform.position;
            
        }

        if (character.transform.position == GameObject.Find("ArrestTarget2").transform.position)
        {
            controller.changeState(controller.ArrestState);
        }

        new WaitForFixedUpdate();
        character.GetComponent<Animator>().SetBool("Move", true);
        character.transform.position = Vector3.MoveTowards(character.transform.position, destination, 4 * Time.deltaTime);
    }

    void FlipCharacter()
    {
        if(Forward)
        {
            Vector3 playerScale = character.transform.localScale;
            playerScale.x = -playerScale.x;
            character.transform.localScale = playerScale;
            Forward = !Forward;
        }
    }
}
