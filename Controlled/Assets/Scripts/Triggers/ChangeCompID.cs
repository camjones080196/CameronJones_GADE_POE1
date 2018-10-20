using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCompID  : DialogueTrigger
{

    public int id;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        GameObject.FindGameObjectWithTag("Computer").GetComponent<DialogueEngine>().ChangeDialogueToID(id, true);
    }
}
