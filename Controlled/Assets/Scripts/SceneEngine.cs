using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEngine : MonoBehaviour {

    private static SceneEngine instance = null;
    string scene;

    public static SceneEngine Instance
    {
        get
        {
            return instance;
        }
    }

    public string Scene
    {
        get
        {
            return scene;
        }

        set
        {
            scene = value;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void NextScene(string nextScene)
    {
        Debug.Log(Scene);
        SceneManager.LoadScene(nextScene);
    }

    public void restart()
    {
        Scene= "Scene1";
        SceneManager.LoadScene(Scene);
    }

    public void findSceneEngine()
    {
        GameObject respawnscene = GameObject.FindGameObjectWithTag("SceneManager");
        respawnscene.GetComponent<SceneEngine>().respawn();
    }

    public void respawn()
    {
        SceneManager.LoadScene(Scene);
    }

    public void quitGame()
    {
        
        Application.Quit();
    }
}
