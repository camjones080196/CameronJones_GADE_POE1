using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableComputer : DialogueTrigger {

    public int id;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        GameObject.FindGameObjectWithTag("Computer").GetComponent<DialogueEngine>().ChangeDialogueToID(4, true);
        GameObject.FindGameObjectWithTag("Trigger2").GetComponent<DialogueEngine>().ChangeDialogueToID(id, true);
        GameObject.FindGameObjectWithTag("Mother").GetComponent<MotherMovement>().startMovement();
        GameObject.FindGameObjectWithTag("Sheila").GetComponent<SheilaMovement>().startMovement();
        GameObject.FindGameObjectWithTag("Dale").GetComponent<DaleMovement>().startMovement();
    }
}
