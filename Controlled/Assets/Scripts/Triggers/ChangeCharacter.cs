using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : DialogueTrigger {

    public GameObject targetCharacter;
    public GameObject currentCharacter;
    public GameObject dialogue;

    Camera mainCam;
    public GameObject Dylan;
    public GameObject Sheila;
    public GameObject Dale;
    public GameObject Ghost;
    Vector3 Destination;
    bool arrived = false;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        
        resetCharacters();
        StartCoroutine(moveToCharater()); 
    }

    public IEnumerator moveToCharater()
    {

        
        targetCharacter.tag = "Player";
        Ghost.transform.position = currentCharacter.transform.position;
        Ghost.SetActive(true);
        mainCam = Camera.main;
        mainCam.transform.SetParent(Ghost.transform);
        mainCam.transform.position = new Vector3(Ghost.transform.position.x, Ghost.transform.position.y, -15);
        
        while (Ghost.transform.position != targetCharacter.transform.position)
        {
            yield return new WaitForFixedUpdate();
            dialogue.SetActive(false);
            Ghost.transform.position = Vector3.MoveTowards(Ghost.transform.position, targetCharacter.transform.position, 1 * Time.deltaTime);
        }

        dialogue.SetActive(true);
        Ghost.SetActive(false);
        mainCam.transform.SetParent(targetCharacter.transform);
        mainCam.transform.position = new Vector3(targetCharacter.transform.position.x, targetCharacter.transform.position.y, -15);
        targetCharacter.GetComponent<PlayerController>().enabled = true;
        targetCharacter.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Cursor.visible = true;
    }

    public void resetCharacters()
    {
        Dylan.tag = "Dylan";
        Sheila.tag = "Sheila";
        Dale.tag = "Dale";

        Dylan.GetComponent<PlayerController>().enabled = false;
        Sheila.GetComponent<PlayerController>().enabled = false;
        Dale.GetComponent<PlayerController>().enabled = false;

        Dylan.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Sheila.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        Dale.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
    }
}
