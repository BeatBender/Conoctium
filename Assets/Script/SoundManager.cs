using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

    private float soundFeedBack;
    private float soundLevel;

    private AudioSource musicSource;
    public static SoundManager instance = null;

    public AudioClip JumpSound;
    public AudioClip AttiranceSound;
    public AudioClip RepulsionSound;
    public AudioClip PortalSound;

    public AudioClip musicLevel1;
    public AudioClip musicLevel2;
    public AudioClip musicLevel3;
    public AudioClip musicLevel4;

    private bool soundLevelStart = false;
    public void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            PlaySoundLevel();
        }
        soundFeedBack = 1F;
        soundLevel = 0.05F;
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (!soundLevelStart)
            {
                PlaySoundLevel();
                soundLevelStart = true;
            }
        }


    }

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
                GetComponent<AudioSource>().PlayOneShot(JumpSound, soundFeedBack);
                break;
            case "attiranceSound":
                GetComponent<AudioSource>().PlayOneShot(AttiranceSound, soundFeedBack);
                break;
            case "repulsionSound":
                GetComponent<AudioSource>().PlayOneShot(RepulsionSound, soundFeedBack);
                break;
            case "portalSound":
                GetComponent<AudioSource>().PlayOneShot(PortalSound, soundFeedBack);
                break;
        }

    }

    public void PlaySoundLevel()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                GetComponent<AudioSource>().PlayOneShot(musicLevel1, soundLevel);
                break;
            case 1:
                GetComponent<AudioSource>().PlayOneShot(musicLevel2, soundLevel);
                break;
            case 2:
                GetComponent<AudioSource>().PlayOneShot(musicLevel3, soundLevel);
                break;
            case 3:
                GetComponent<AudioSource>().PlayOneShot(musicLevel4, soundLevel);
                break;
        }
    }

    public void StopSoundLevel()
    {
        GetComponent<AudioSource>().Stop();
        soundLevelStart = false;
    }

    public void SoundOn()
    {
        soundFeedBack = 1F;
        soundLevel = 0.05F;
    }

    public void SoundOff()
    {
        soundFeedBack = 0;
        soundLevel = 0;
    }
}
