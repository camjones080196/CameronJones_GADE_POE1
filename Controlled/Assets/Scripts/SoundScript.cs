using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

    public AudioClip MusicClip;
    public AudioClip BackgroundClip;
    public AudioClip OpenDoor;
    public AudioClip CloseDoor;
    public AudioClip ComputerClick;
    public AudioClip NormalClick;
    public AudioClip Prompt;
    public AudioSource MusicSource;
    public AudioSource BackgroundSource;
    public AudioSource SoundEffects;
    public AudioSource DoorSounds;
    public AudioSource Prompting;


    void Start () {
        MusicSource.clip = MusicClip;
        BackgroundSource.clip = BackgroundClip;
        MusicSource.Play();
        BackgroundSource.Play();
	}
	
	
	void Update () {
		
	}

    public void prompt()
    {
        Prompting.clip = Prompt;
        Prompting.Play();
    }
    public void openDoor()
    {
        DoorSounds.clip = OpenDoor;
        DoorSounds.Play();
    }

    public void closeDoor()
    {
        DoorSounds.clip = CloseDoor;
        DoorSounds.Play();
    }

    public void normalClick()
    {
        SoundEffects.clip = NormalClick;
        SoundEffects.Play();
    }

    public void computerClick()
    {
        SoundEffects.clip = ComputerClick;
        SoundEffects.Play();
    }
}
