using System.Collections;
using UnityEngine;

[System.Serializable]
public class TxtDialogue {

    public string messageText;
    public string[] dialogueChoice = new string[0];
    public int[] choicePath = new int[0];
    public bool hasTrigger = false;               
    public int triggerID;

    [HideInInspector]
    public int ownerID;
		
	
}
