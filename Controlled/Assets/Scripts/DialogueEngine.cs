using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEngine : MonoBehaviour {

    public int dialogueID;

    [HideInInspector]
    public List<TxtDialogue> message = new List<TxtDialogue>();
    [HideInInspector]
    public List<int> messageID = new List<int>();
    [HideInInspector]
    public bool enter = false;
    [HideInInspector]
    public int counter = 0;

    protected GameObject player;
    protected bool talking = false;
    protected bool changeID = false;
    private bool interacted = false;
    protected int newID;
    private bool enabled = false;

    public bool Interacted
    {
        get
        {
            return interacted;
        }

        set
        {
            interacted = value;
        }
    }

    public bool Enabled
    {
        get
        {
            return enabled;
        }

        set
        {
            enabled = value;
        }
    }

    void Start ()
    {
        LoadDBDialogue();
        
    }
	
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) && enter && !talking && Time.timeScale != 0.0f)
        {
            GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>().normalClick();
            DialoguePanel.hideOptions();
            NextMessage();
            Interacted = true;
        }

        if (Time.timeScale == 0)
        {
            talking = true;
            Invoke("EnableTalking", 0.1f);            
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
             GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>().prompt();
                counter = 0;
                player = other.gameObject;
                enter = true;
                DialoguePanel.showOptions();
            
        }

    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            counter = 0;
            enter = false;
            CloseTalk();
            DialoguePanel.hideOptions();
        }

    }
  



    public virtual void NextMessage()
    {
        if (this.gameObject.name != "Computer")
        {
            GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>().normalClick();
        }
        else
        {
            GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>().computerClick();
        }

        if (!enter)
        {
            return;
        }

        
        if (counter < message.Count)
        {
            if (CheckSpecialConditions(counter)) 
            {
                return;
            }
        }
        

        counter++;
        

        if (counter > message.Count)
        {
           CloseTalk();
        }
        else
        {
            Time.timeScale = 0.0f;
            Cursor.visible = true;
            ShowGUI();
        }
    }

    public virtual void GoToNextMessage(int messageNumber)
    {
        if (this.gameObject.name != "Computer")
        {
            GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>().normalClick();
        }
        else
        {
            GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundScript>().computerClick();
        }

        if (!enter)
        {
            return;
        }

        
        if (messageNumber <= message.Count)
        {
            if (CheckSpecialConditions(messageNumber))   
            {
                return;
            }
        }

        counter = messageNumber + 1;
        
        if (counter > message.Count)
        {
            CloseTalk();
        }
        else
        {
            Time.timeScale = 0.0f;
            Cursor.visible = true;
            ShowGUI();
        }
    }

    public virtual bool CheckSpecialConditions(int messageNumber)
    {
        return false;
    }

    protected void ShowGUI()   
    {
        talking = true;
        DialoguePanel.currentDialogue = this;
        DialoguePanel.ShowDialog();
    }

    void HideGUI()   
    {
        DialoguePanel.EndDialog();
        Invoke("EnableTalking", 0.1f);
    }

   

    protected void CloseTalk()
    {
        HideGUI();
        Time.timeScale = 1.0f;

        Cursor.visible = false;

        counter = 0;
        ChangeID();
    }

    void EnableTalking()
    {
        talking = false;
    }

    public void LoadDBDialogue()
    {
        ResetMessageID();

        message = new List<TxtDialogue>();

        for(int k = 0; k < messageID.Count; k++)
        {
            message.Add(GameObject.FindWithTag("DialogueDatabase").GetComponent<DialogueDB>().database[messageID[k]]);
        }
    }

    public void UpdateDialogueInDatabase()
    {
        messageID = new List<int>();

        GameObject.FindWithTag("DialogueDatabase").GetComponent<DialogueDB>().CleanID(dialogueID);

        for (int k = 0; k < message.Count; k++)
        {
            message[k].ownerID = dialogueID;

            messageID.Add(GameObject.FindWithTag("DialogueDatabase").GetComponent<DialogueDB>().InsertToDB(message[k]));
        }
    }

    void ResetMessageID()
    {
        messageID = new List<int>();

        messageID = GameObject.FindWithTag("DialogueDatabase").GetComponent<DialogueDB>().GetDialogueIDList(dialogueID);
    }

    public void ChangeDialogueToID(int _dialogueID, bool instant)
    {

        changeID = true;
        newID = _dialogueID;

        if (instant)
        {
            ChangeID();
        }
    }

    void ChangeID()
    {
        if (changeID)
        {
            dialogueID = newID;
            changeID = false;
            LoadDBDialogue();
        }
    }
}
