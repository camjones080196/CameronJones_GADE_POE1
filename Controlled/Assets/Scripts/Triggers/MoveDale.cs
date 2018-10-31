using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDale : DialogueTrigger
{
    public GameObject character;
    public GameObject target;
    public bool forward;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        StopAllCoroutines();
        character.GetComponent<Animator>().SetBool("Move", true);
        character.GetComponent<Animator>().SetBool("Shoot", false);
        StartCoroutine(moveDale());


    }

    public IEnumerator moveDale()
    {
        while (character.transform.position != target.transform.position)
        {
            yield return new WaitForFixedUpdate();
            character.transform.position = Vector3.MoveTowards(character.transform.position, target.transform.position, 2 * Time.deltaTime);
        }

      
        if (!forward)
        {
            Vector3 playerScale = character.transform.localScale;
            playerScale.x = -playerScale.x;
            character.transform.localScale = playerScale;
        }
        character.GetComponent<Animator>().SetBool("Shoot", true);
        character.GetComponent<Animator>().SetBool("Move", false);
    }
}
