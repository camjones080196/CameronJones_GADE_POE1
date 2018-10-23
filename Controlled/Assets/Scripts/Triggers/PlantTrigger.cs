using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTrigger : DialogueTrigger
{

    public GameObject[] plants;
    public GameObject computer;
    

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        
        
        for (int i = 0; i < plants.Length; i++)
        {
            plants[i].GetComponent<DialogueEngine>().ChangeDialogueToID(Random.RandomRange(5,8), true);
        }

        computer.GetComponent<Collider2D>().enabled = true;
    }

}
