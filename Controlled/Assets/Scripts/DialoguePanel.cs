using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DialoguePanel : MonoBehaviour {

    public static GameObject dialogueBox;
    public static GameObject Options;
    public static Text dialogue;
    public static GameObject choice1;
    public static GameObject choice2;
    public static GameObject next;
   

    public static Text choice1Text;
    public static Text choice2Text;

    public static DialogueEngine currentDialogue;

    int temp = 0;

    void Start()
    {
        dialogueBox = transform.GetChild(0).gameObject;
        dialogue = dialogueBox.transform.Find("DialogueText").GetComponent<Text>();

        Options = transform.GetChild(1).gameObject;

        choice1 = dialogueBox.transform.Find("Choice1").gameObject;
        choice2 = dialogueBox.transform.Find("Choice2").gameObject;
        next = dialogueBox.transform.Find("Next").gameObject;

        choice1Text = choice1.transform.GetChild(0).GetComponent<Text>();
        choice2Text = choice2.transform.GetChild(0).GetComponent<Text>();
    }

    public static void ShowDialog()
    {
        int messageIndex = currentDialogue.counter - 1;
        dialogueBox.SetActive(true);
        dialogue.text = currentDialogue.message[messageIndex].messageText;

        DisableAllButtons();  
        EnableChoices(currentDialogue.message[messageIndex].dialogueChoice.Length);  
    }

    public static void EndDialog()
    {
        dialogueBox.SetActive(false);
    }

    public static void showOptions()
    {
        Options.SetActive(true);
    }

    public static void hideOptions()
    {
        Options.SetActive(false);
    }

    public void NextMessage()
    {
        currentDialogue.NextMessage();
        /*if (temp == 0)
        {
            currentDialogue.NextMessage();
        }
        else if (temp == 1)
        {
            currentDialogue.GoToNextMessage(currentDialogue.message[currentDialogue.counter - 1].choicePath[0]);
        }
        else if (temp == 2)
        {
            currentDialogue.GoToNextMessage(currentDialogue.message[currentDialogue.counter - 1].choicePath[1]);
        }

        temp = 0;*/
    }

    public void Choice1()
    {
        //dialogue.text = currentDialogue.message[currentDialogue.counter - 1].dialogueChoice[0];
        //next.SetActive(true);
        //choice1.SetActive(false);
        //choice2.SetActive(false);
        //temp = 1;
        currentDialogue.GoToNextMessage(currentDialogue.message[currentDialogue.counter - 1].choicePath[0]);
    }

    public void Choice2()
    {
        //dialogue.text = currentDialogue.message[currentDialogue.counter - 1].dialogueChoice[1]; 
        //next.SetActive(true);
        //choice1.SetActive(false);
        //choice2.SetActive(false);
        //temp = 2;
        currentDialogue.GoToNextMessage(currentDialogue.message[currentDialogue.counter - 1].choicePath[1]);
    }

    public static void DisableAllButtons()
    {
        choice1.SetActive(false);
        choice2.SetActive(false);
        next.SetActive(false);
    }

    public static void EnableChoices(int numberOfChoices)
    {
        if (numberOfChoices == 0)
        {
            next.SetActive(true);
            EventSystem.current.SetSelectedGameObject(next);
        }
        else if (numberOfChoices == 1)
        {
            choice1.SetActive(true);
            choice1Text.text = currentDialogue.message[currentDialogue.counter - 1].dialogueChoice[0];
        }
        else if (numberOfChoices == 2)
        {
            choice1.SetActive(true);
            choice1Text.text = currentDialogue.message[currentDialogue.counter - 1].dialogueChoice[0];
            choice2.SetActive(true);
            choice2Text.text = currentDialogue.message[currentDialogue.counter - 1].dialogueChoice[1];
        }
    }

    }
