using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCharacter : DialogueTrigger
{

    

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        Cursor.visible = true;
        GetComponentInParent<Animator>().SetBool("Move", false);
        GetComponentInParent<SheilaMovement>().startWaitTime = 0;
        GetComponentInParent<SheilaMovement>().StopAllCoroutines();
    }
}
