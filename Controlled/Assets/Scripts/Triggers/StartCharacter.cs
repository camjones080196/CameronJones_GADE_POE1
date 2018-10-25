using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCharacter : DialogueTrigger
{



    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        GetComponentInParent<AIMovement>().startMovement();
    }
}
