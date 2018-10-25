using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterDialogue : DialogueTrigger
{
    public GameObject character;
    public int id;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        character.GetComponent<DialogueEngine>().ChangeDialogueToID(id, true);
    }
}
