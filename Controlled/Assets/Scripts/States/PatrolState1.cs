using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState1 : State
{
    private bool forward = true;
    private float currentX;
    float movement;
    int count = 0;

    private Vector3 start;
    private Vector3 destination;

    public PatrolState1(StateMachine controller, GameObject character) : base(controller, character)
    {
        destination = GameObject.Find("PatrolTarget1").transform.position;
        currentX = character.transform.position.x;
    }

    
    public override void Execute()
    {
        if(character.transform.position == GameObject.Find("PatrolTarget1").transform.position)
        {
            destination = GameObject.Find("PatrolTarget2").transform.position;
            FlipCharacter();
        }

        if (character.transform.position == GameObject.Find("PatrolTarget2").transform.position)
        {
            destination = GameObject.Find("PatrolTarget1").transform.position;
            FlipCharacter();
        }

        if(count%500 == 0)
        {
            controller.changeState(controller.IdleState);
        }

        new WaitForFixedUpdate();
        character.GetComponent<Animator>().SetBool("Move", true);
        character.transform.position = Vector3.MoveTowards(character.transform.position, destination, 1 * Time.deltaTime);
        count++;
        

    }

    

    void FlipCharacter()
    {
        movement = character.transform.position.x;

        if ((movement < currentX && !forward) || (movement > currentX && forward))
        {
            Vector3 playerScale = character.transform.localScale;
            playerScale.x = -playerScale.x;
            character.transform.localScale = playerScale;
            forward = !forward;
            currentX = character.transform.position.x;
        }
    }
}

    


