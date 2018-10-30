using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToComputer : DialogueTrigger {

    public GameObject character1;
    public GameObject character2;
    public string currentCharcter;
    public GameObject[] targets1;
    public GameObject[] targets2;

    
    private bool forward1 = true;
    private bool forward2 = true;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        character1.GetComponent<AIMovement>().StopAllCoroutines();
        character2.GetComponent<AIMovement>().StopAllCoroutines();
        
        if(currentCharcter == "Dylan")
        {
            forward1 = character1.GetComponent<SheilaMovement>().Forward;
            forward2 = character2.GetComponent<DaleMovement>().Forward;
        }

        if (currentCharcter == "Sheila")
        {
            forward1 = character1.GetComponent<DylanMovement>().Forward;
            forward2 = character2.GetComponent<DaleMovement>().Forward;
        }

        if (currentCharcter == "Dale")
        {
            forward1 = character1.GetComponent<DylanMovement>().Forward;
            forward2 = character2.GetComponent<SheilaMovement>().Forward;
        }
        StartCoroutine(moveCharacter1ToComputer());
        StartCoroutine(moveCharacter2ToComputer());
        

    }

    IEnumerator moveCharacter1ToComputer()
    {
        for (int i = 0; i < targets1.Length; i++)
        {
            while (character1.transform.position != targets1[i].transform.position)
            {
                character1.GetComponent<Animator>().SetBool("Move", true);
                yield return new WaitForFixedUpdate();
                character1.transform.position = Vector3.MoveTowards(character1.transform.position, targets1[i].transform.position, 3 * Time.deltaTime);
                FlipCharacter1();
            }
        }

        character1.GetComponent<Animator>().SetBool("Move", false);
    }

    IEnumerator moveCharacter2ToComputer()
    {
        for (int i = 0; i < targets2.Length; i++)
        {
            while (character2.transform.position != targets2[i].transform.position)
            {
                character2.GetComponent<Animator>().SetBool("Move", true);
                yield return new WaitForFixedUpdate();
                character2.transform.position = Vector3.MoveTowards(character2.transform.position, targets2[i].transform.position, 3 * Time.deltaTime);
                FlipCharacter2();
            }
        }

        character2.GetComponent<Animator>().SetBool("Move", false);
    }

    void FlipCharacter1()
    {
        if (forward1)
        {
            Vector3 playerScale = character1.transform.localScale;
            playerScale.x = -playerScale.x;
            character1.transform.localScale = playerScale;
            forward1 = !forward1;
        }
    }

    void FlipCharacter2()
    {
        if (forward2)
        {
            Vector3 playerScale = character2.transform.localScale;
            playerScale.x = -playerScale.x;
            character2.transform.localScale = playerScale;
            forward2 = !forward2;
        }
    }
}
