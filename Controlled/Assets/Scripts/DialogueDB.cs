using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DialogueDB : MonoBehaviour {

    public static DialogueDB instance;
    public string fileName;
    public List<TxtDialogue> database = new List<TxtDialogue>();

    private void Awake()
    {
        instance = this;
        LoadDB();
    }

    public int InsertToDB(TxtDialogue dialogue)
    {
        int dialoguePos;

        if (database.Count == 0)
        {
            database.Add(new TxtDialogue());
        }

        dialoguePos = FindLastEmptySpot();

        if(dialoguePos == 0)
        {
            dialoguePos = database.Count;
            database.Add(dialogue);
        }
        else
        {
            database[dialoguePos] = dialogue;
        }

        return dialoguePos; 
    }

    public int FindLastEmptySpot()
    {
        for(int k = 0; k < database.Count; k++)
        {
            if(database[k].ownerID == 0)
            {
                return k;
            }
        }

        return 0;
    }

    public List<int> GetDialogueIDList(int dialogueID)
    {
        List<int> tempList = new List<int>();

        for(int k = 0; k < database.Count; k++)
        {
            if(database[k].ownerID == dialogueID)
            {
                tempList.Add(k);
            }
        }

        return tempList;
    }

    public void CleanID(int ID)
    {
        for(int k = 0; k < database.Count; k++)
        {
            if(database[k].ownerID == ID)
            {
                database[k] = new TxtDialogue();
            }
        }
    }

    public void SaveDB()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/StreamingAssets/" + fileName);

        bf.Serialize(file, database);
        file.Close();
    }

    public void LoadDB()
    {
        if(File.Exists(Application.dataPath + "/StreamingAssets/" + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/StreamingAssets/" + fileName, FileMode.Open);
          
            database = (List<TxtDialogue>)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log("DB did not load, check filename");
        }
    }

}
