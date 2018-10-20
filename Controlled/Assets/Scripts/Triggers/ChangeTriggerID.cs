using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTriggerID : DialogueTrigger {

    public int id;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        GameObject.FindGameObjectWithTag("Trigger1").GetComponent<DialogueEngine>().ChangeDialogueToID(id, true);
    }
}
