using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{

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
                GetComponent<AudioSource>().PlayOneShot(JumpSound, 1f);
                break;
            case "attiranceSound":
                GetComponent<AudioSource>().PlayOneShot(AttiranceSound, 1f);
                break;
            case "repulsionSound":
                GetComponent<AudioSource>().PlayOneShot(RepulsionSound, 1f);
                break;
            case "portalSound":
                GetComponent<AudioSource>().PlayOneShot(PortalSound, 1f);
                break;
        }

    }

    public void PlaySoundLevel()
    {
        int rand = Random.Range(0, 4);
        switch (rand)
        {
            case 0:
                GetComponent<AudioSource>().PlayOneShot(musicLevel1, 0.05f);
                break;
            case 1:
                GetComponent<AudioSource>().PlayOneShot(musicLevel2, 0.05f);
                break;
            case 2:
                GetComponent<AudioSource>().PlayOneShot(musicLevel3, 0.05f);
                break;
            case 3:
                GetComponent<AudioSource>().PlayOneShot(musicLevel4, 0.05f);
                break;
        }
    }

    public void StopSoundLevel()
    {
        GetComponent<AudioSource>().Stop();
        soundLevelStart = false;
    }
}
