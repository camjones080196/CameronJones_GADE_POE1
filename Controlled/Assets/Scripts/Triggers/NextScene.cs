using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : DialogueTrigger
{
    public string currrentScene;
    public string nextScene;
    GameObject sceneEngine; 

    public override void FireTrigger()
    {
        if (triggerOnce && triggered)
        {
            return;
        }
        triggered = true;

        sceneEngine = GameObject.FindGameObjectWithTag("SceneManager");
        sceneEngine.GetComponent<SceneEngine>().Scene = currrentScene;
        sceneEngine.GetComponent<SceneEngine>().NextScene(nextScene);
    }
}
