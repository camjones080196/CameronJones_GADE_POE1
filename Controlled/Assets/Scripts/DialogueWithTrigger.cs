using UnityEngine;
using System.Collections;

public class DialogueWithTrigger : DialogueEngine
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enter && !talking && Time.timeScale != 0.0f)
        {
            DialoguePanel.hideOptions();
            NextMessage();
            Interacted = true;
        }

        if (Time.timeScale == 0)
        {
            talking = true;
            Invoke("EnableTalking", 0.1f);
        }
    }


    public override bool CheckSpecialConditions(int messageNumber)
    {
        if (message[messageNumber].hasTrigger)
        {
            ActivateTrigger(message[messageNumber].triggerID);
        }
        return false;
    }

    
    void ActivateTrigger(int index)
    {
        //		GetComponent<DialogueTriggerContainer>().Triggers[index].gameObject.SetActive(true);
        GetComponent<DialogueTriggerContainer>().Triggers[index].FireTrigger();
    }
}