using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (DialogueEngine))]
public class BaseDialogueEditor : Editor {

	public override void OnInspectorGUI(){
		base.OnInspectorGUI();
		
		if (GUILayout.Button("Update Database")){
			GameObject.FindWithTag("Dialogue Database").GetComponent<DialogueDB>().LoadDB(); //For making sure the database is updated (load database before updating)

			Selection.activeGameObject.GetComponent<DialogueEngine>().UpdateDialogueInDatabase();
		}
		
		if (GUILayout.Button("Load from Database")){
			Selection.activeGameObject.GetComponent<DialogueEngine>().LoadDBDialogue();
		}
	}
}
