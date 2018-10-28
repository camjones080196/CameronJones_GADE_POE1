using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowTrigger : MonoBehaviour {

    public int id;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Crate")
        {
            DialoguePanel.hideOptions();
            Cursor.visible = false;
            this.GetComponent<DialogueEngine>().ChangeDialogueToID(id, true);
            this.gameObject.GetComponent<DialogueWithTrigger>().enter = true;
            this.gameObject.GetComponent<DialogueWithTrigger>().counter = 0;
            this.gameObject.GetComponent<DialogueWithTrigger>().NextMessage();
        }
    }
}
