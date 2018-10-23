using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlantDialogue : DialogueTrigger {

    int rightPlant;
    public GameObject[] plants;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        rightPlant = Random.Range(0, plants.Length);

        plants[rightPlant].GetComponent<DialogueEngine>().ChangeDialogueToID(1, true);

        for(int i = 0; i < plants.Length; i++)
        {
            if(plants[i] != plants[rightPlant])
            {
                plants[i].GetComponent<DialogueEngine>().ChangeDialogueToID(Random.Range(2, 4), true);
            }
        }
    }
}
