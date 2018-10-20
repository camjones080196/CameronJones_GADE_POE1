using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : DialogueTrigger {

    private bool forwardS = true;
    private float currentXS;
    float movementS;
    private bool forwardD = true;
    private float currentXD;
    float movementD;
    public GameObject Sheila;
    public GameObject Dale;

    int speed = 2;

    public GameObject[] sheilaTargets;
    public GameObject[] DaleTargets;

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }

        triggered = true;
        currentXS = Sheila.transform.position.x;
        currentXD = Dale.transform.position.x;
        StartCoroutine(moveSheila());
        StartCoroutine(moveDale());

    }

    public IEnumerator moveSheila()
    {
        for (int i = 0; i < sheilaTargets.Length; i++)
        {
            while (Sheila.transform.position != sheilaTargets[i].transform.position)
            {
                yield return new WaitForFixedUpdate();
                Sheila.GetComponent<Animator>().SetBool("Move", true);
                Sheila.transform.position = Vector3.MoveTowards(Sheila.transform.position, sheilaTargets[i].transform.position, speed * Time.deltaTime);
                FlipSheila();
            }
            Sheila.GetComponent<Animator>().SetBool("Move", false);
            StopCoroutine(moveSheila());
        }
    }

    public IEnumerator moveDale()
    {
        for (int i = 0; i < DaleTargets.Length; i++)
        {
            while (Dale.transform.position != DaleTargets[i].transform.position)
            {
                yield return new WaitForFixedUpdate();
                Dale.GetComponent<Animator>().SetBool("Move", true);
                Dale.transform.position = Vector3.MoveTowards(Dale.transform.position, DaleTargets[i].transform.position, speed * Time.deltaTime);
                FlipDale();
            }
            Dale.GetComponent<Animator>().SetBool("Move", false);
            StopCoroutine(moveDale());
        }
    }

    void FlipSheila()
    {
        movementS = Sheila.transform.position.x;

        if ((movementS > currentXS && !forwardS) || (movementS < currentXS && forwardS))
        {
            Vector3 playerScale = Sheila.transform.localScale;
            playerScale.x = -playerScale.x;
            Sheila.transform.localScale = playerScale;
            forwardS = !forwardS;
        }
    }

    void FlipDale()
    {
        movementD = Dale.transform.position.x;

        if ((movementD > currentXD && !forwardD) || (movementD < currentXD && forwardD))
        {
            Vector3 playerScale = Dale.transform.localScale;
            playerScale.x = -playerScale.x;
            Dale.transform.localScale = playerScale;
            forwardD = !forwardD;
        }
    }
}
