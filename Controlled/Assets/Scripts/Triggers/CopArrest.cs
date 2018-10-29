using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopArrest : DialogueTrigger
{
    public GameObject cop;
    

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        GameObject.Find("LineOFSight").active = false;
        cop.GetComponent<StateMachine>().changeState(cop.GetComponent<StateMachine>().ArrestState2);
    }
}
