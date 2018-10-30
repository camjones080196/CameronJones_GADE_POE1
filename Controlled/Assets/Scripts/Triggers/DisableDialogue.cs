using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDialogue : DialogueTrigger
{
    public GameObject[] objects;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

       for(int i = 0; i < objects.Length; i++)
       {
            objects[i].GetComponent<BoxCollider2D>().enabled = false;
       }
    }
}

