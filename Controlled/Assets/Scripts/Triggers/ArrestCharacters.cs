using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrestCharacters : MonoBehaviour {

    public GameObject cop;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DialoguePanel.hideOptions();
            Cursor.visible = false;
            this.gameObject.GetComponent<DialogueWithTrigger>().enter = true;
            this.gameObject.GetComponent<DialogueWithTrigger>().counter = 0;
            this.gameObject.GetComponent<DialogueWithTrigger>().NextMessage();
            cop.GetComponent<StateMachine>().changeState(cop.GetComponent<StateMachine>().ArrestState);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            cop.GetComponent<StateMachine>().changeState(cop.GetComponent<StateMachine>().PatrolState1);
            this.gameObject.active = false;
        }
    }


}
