using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : DialogueTrigger {

    public string character;
    Camera mainCam;
    public GameObject Dylan;
    public GameObject Sheila;
    public GameObject Dale;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        Dylan.tag = "Dylan";
        Sheila.tag = "Sheila";
        Dale.tag = "Dale";

        Dylan.GetComponent<PlayerController>().enabled = false;
        Sheila.GetComponent<PlayerController>().enabled = false;
        //Dale.GetComponent<PlayerController>().enabled = false;

        Dylan.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Sheila.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        //Dale.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        if (character == "Sheila")
        {
            mainCam = Camera.main;
            mainCam.transform.SetParent(Sheila.transform);
            mainCam.transform.position = new Vector3(Sheila.transform.position.x, Sheila.transform.position.y, -15);
            
            Sheila.GetComponent<PlayerController>().enabled = true;
            Sheila.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Sheila.tag = "Player";
            
        }
    }
}
