using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{ 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            DialoguePanel.hideOptions();
            this.gameObject.GetComponent<DialogueWithTrigger>().enter = true;
            this.gameObject.GetComponent<DialogueWithTrigger>().counter = 0;
            this.gameObject.GetComponent<DialogueWithTrigger>().NextMessage();
            this.gameObject.active = false;
        }
    }
}
