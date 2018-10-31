using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : DialogueTrigger
{
    public GameObject character1;
    public GameObject character2;
    public GameObject Player;
    bool forward;


    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        forward = Player.GetComponent<PlayerController>().Forward;
        flipCharacter1();
        flipCharacter2();
        flipPlayer();
    }

    public void flipCharacter1()
    {
        Vector3 playerScale = character1.transform.localScale;
        playerScale.x = -playerScale.x;
        character1.transform.localScale = playerScale;
    }

    public void flipCharacter2()
    {
        Vector3 playerScale = character2.transform.localScale;
        playerScale.x = -playerScale.x;
        character2.transform.localScale = playerScale;
    }

    public void flipPlayer()
    {
        if (forward)
        {
            Vector3 playerScale = Player.transform.localScale;
            playerScale.x = -playerScale.x;
            Player.transform.localScale = playerScale;
        }
    }
}
