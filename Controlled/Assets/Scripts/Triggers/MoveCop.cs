using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCop : DialogueTrigger
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

        character.SetActive(true);
        character.GetComponent<Animator>().SetBool("Move", true);
        StartCoroutine(moveCop());
    }

    public IEnumerator moveCop()
    {
        while (character.transform.position != target.transform.position)
        {
            yield return new WaitForFixedUpdate();
            character.transform.position = Vector3.MoveTowards(character.transform.position, target.transform.position, 4 * Time.deltaTime);
        }

        character.GetComponent<Animator>().SetBool("Move", false);
    }


}
