using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : DialogueTrigger {

    public int id;
    public GameObject obj;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        obj.GetComponent<DialogueEngine>().ChangeDialogueToID(id, true);
    }
}
