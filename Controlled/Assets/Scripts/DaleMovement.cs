using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaleMovement : AIMovement
{
    private Animator anim;
    private bool forward = true;
    private float currentX;
    float movement;

    public bool Forward
    {
        get
        {
            return forward;
        }

        set
        {
            forward = value;
        }
    }

    public void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        currentX = transform.position.x;
    }

    public override void getTargets()
    {
        for (int k = 0; k < targets.Length; k++)
        {
            points.Enqueue(targets[k].transform.position);
        }

        newPos = points.Peek();
    }

    public override IEnumerator moveAI()
    {
        yield return new WaitForSeconds(startWaitTime);

        while (points.Count > 0)
        {
            yield return new WaitForFixedUpdate();
            if (this.transform.position == newPos)
            {
                points.Dequeue();

                if (points.Count > 0)
                {
                    newPos = points.Peek();
                }
                else
                {
                    resetPoints();
                }
                anim.SetBool("Move", false);
                currentX = transform.position.x;
                yield return new WaitForSeconds(waitTime);
            }
            else
            {
                anim.SetBool("Move", true);
                this.transform.position = Vector3.MoveTowards(this.transform.position, newPos, speed * Time.deltaTime);
                FlipPlayer();
            }

        }
    }

    void FlipPlayer()
    {
        movement = this.transform.position.x;

        if ((movement > currentX && !Forward) || (movement < currentX && Forward))
        {
            Vector3 playerScale = transform.localScale;
            playerScale.x = -playerScale.x;
            transform.localScale = playerScale;
            Forward = !Forward;
        }
    }

    public void resetPoints()
    {
        getTargets();
    }

}