﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource musicSource;                 
    public static SoundManager instance = null;     

    public AudioClip JumpSound;
    public AudioClip SwooshSound;

    void Awake()
    {
        //Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }


    public void PlaySound(string choix)
    {
        switch (choix)
        {
            case "jumpSound":
                GetComponent<AudioSource>().PlayOneShot(JumpSound);
                break;

            case "swooshSound":
                GetComponent<AudioSource>().PlayOneShot(SwooshSound);
                break;
        }
        
    }



}