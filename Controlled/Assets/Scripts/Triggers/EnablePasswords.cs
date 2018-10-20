using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePasswords : DialogueTrigger
{

    public int id;
    public int id2;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        GameObject.FindGameObjectWithTag("Bedside").GetComponent<DialogueEngine>().ChangeDialogueToID(5, true);
        GameObject.FindGameObjectWithTag("Poster").GetComponent<DialogueEngine>().ChangeDialogueToID(7, true);
        GameObject.FindGameObjectWithTag("Trigger1").GetComponent<DialogueEngine>().ChangeDialogueToID(id, true);
        GameObject.FindGameObjectWithTag("Trigger2").GetComponent<DialogueEngine>().ChangeDialogueToID(id2, true);
    }
}
