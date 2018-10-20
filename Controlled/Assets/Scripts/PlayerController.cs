using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Animator anim;
    private static PlayerController instance = null;

   

    private bool forward = true;

    public static PlayerController Instance
    {
        get
        {
            return instance;
        }
    }

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

    /*private void Awake()
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
    }*/

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        ResetValues();
        HandleInput();
        
    }

    private void HandleInput()
    {
        FlipPlayer();

        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            anim.SetBool("Move", true);
        }

        if (Input.GetKey("a"))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            anim.SetBool("Move", true);
        }

        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
            anim.SetBool("Move", true);
        }

        if (Input.GetKey("s"))
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
            anim.SetBool("Move", true);
        }
    }

    void FlipPlayer()
    {
        float movement = Input.GetAxis("Horizontal");

        if ((movement > 0 && !Forward) || (movement < 0 && Forward))
        {
            Vector3 playerScale = transform.localScale;
            playerScale.x = -playerScale.x;
            transform.localScale = playerScale;
            Forward = !Forward;
        }
    }

    void ResetValues()
    {
        anim.SetBool("Move", false);
    }
}
