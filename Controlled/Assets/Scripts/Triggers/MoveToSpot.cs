using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToSpot : DialogueTrigger
{
    public GameObject character;
    public GameObject window;

    public GameObject[] targets;
    

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        window.GetComponent<DialogueEngine>().enabled = false;
        window.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(moveCharacter());
    }

    public IEnumerator moveCharacter()
    {
            while (character.transform.position != targets[0].transform.position)
            {
                yield return new WaitForFixedUpdate();
                character.GetComponent<Animator>().SetBool("Move", true);
                character.transform.position = Vector3.MoveTowards(character.transform.position, targets[0].transform.position, 2 * Time.deltaTime);
            }
            character.GetComponent<Animator>().SetBool("Move", false);
            //yield return new WaitForSeconds(2);
            character.transform.position = targets[1].transform.position;
            character.GetComponent<BoxCollider2D>().isTrigger = false;
            character.GetComponent<PlayerController>().Forward = false;


    }
    }
