using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class AIMovement : MonoBehaviour {

    public float speed;
    public GameObject[] targets;
    public Vector3 newPos;
    public float startWaitTime;
    public float waitTime;

    public CustomQueue<Vector2> points = new CustomQueue<Vector2>();

    public abstract void getTargets();
    public abstract IEnumerator moveAI();

    public void startMovement()
    {
        getTargets();
        StartCoroutine(moveAI());
    }
    
        
    
}
