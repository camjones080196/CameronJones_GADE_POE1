using UnityEngine;
using System.Collections;

public class ChangeDialogueID : DialogueTrigger
{

    public int id;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        GetComponentInParent<DialogueEngine>().ChangeDialogueToID(id, false);
    }
}

