using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacters : DialogueTrigger{
    public GameObject character1;
    public GameObject character2;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        //character1.GetComponent<AIMovement>().startMovement();
        //character2.GetComponent<AIMovement>().startMovement();


    }
}
