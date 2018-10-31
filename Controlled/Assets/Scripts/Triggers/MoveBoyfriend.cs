using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBoyfriend : DialogueTrigger
{
    public GameObject character;
    public GameObject target;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        character.SetActive(true);
        character.GetComponent<Animator>().SetBool("Move", true);
        character.GetComponent<Animator>().SetBool("Shoot", false);
        StartCoroutine(moveboyfriend());

        
    }

    public IEnumerator moveboyfriend()
    {
        while (character.transform.position != target.transform.position)
        {
            yield return new WaitForFixedUpdate();
            character.transform.position = Vector3.MoveTowards(character.transform.position, target.transform.position, 3 * Time.deltaTime);
        }

        character.GetComponent<Animator>().SetBool("Move", false);
        character.GetComponent<Animator>().SetBool("Shoot", true);
    }
}
