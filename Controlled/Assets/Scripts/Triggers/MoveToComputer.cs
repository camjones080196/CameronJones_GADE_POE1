using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToComputer : DialogueTrigger {

    public GameObject character1;
    public GameObject character2;
    public GameObject[] targets1;
    public GameObject[] targets2;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        character1.GetComponent<AIMovement>().StopAllCoroutines();
        character2.GetComponent<AIMovement>().StopAllCoroutines();
        StartCoroutine(moveCharacter1ToComputer());
        StartCoroutine(moveCharacter2ToComputer());

    }

    IEnumerator moveCharacter1ToComputer()
    {
        for (int i = 0; i < targets1.Length; i++)
        {
            while (character1.transform.position != targets1[i].transform.position)
            {
                yield return new WaitForFixedUpdate();
                character1.transform.position = Vector3.MoveTowards(character1.transform.position, targets1[i].transform.position, 3 * Time.deltaTime);
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
                yield return new WaitForFixedUpdate();
                character2.transform.position = Vector3.MoveTowards(character2.transform.position, targets2[i].transform.position, 3 * Time.deltaTime);
            }
        }

        character2.GetComponent<Animator>().SetBool("Move", false);
    }
}
