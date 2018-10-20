using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opendoor : MonoBehaviour {

    Animator anim;
    BoxCollider2D door;
    

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Door1").GetComponent<Animator>();
        door = GameObject.FindGameObjectWithTag("Door1").GetComponent<BoxCollider2D>();
    }

    
    void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.gameObject.tag == "Player" && this.gameObject.GetComponent<DialogueEngine>().Interacted == true)
        {
            anim.SetBool("Closed", false);
            GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>().openDoor();
            anim.SetBool("Opened", true);
            door.enabled = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player" && this.gameObject.GetComponent<DialogueEngine>().Interacted == true)
        {   
            anim.SetBool("Opened", false);
            GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>().closeDoor();
            anim.SetBool("Closed", true);
            door.enabled = true;
            this.gameObject.GetComponent<DialogueEngine>().Interacted = false;
        }
    }
}
