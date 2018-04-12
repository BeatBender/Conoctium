using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    private float SOUND_FEEDBACK_SAUT = 0.5f;
    private float SOUND_FEEDBACK_ATTRACT = 0.3f;
    private float SOUND_FEEDBACK_REPULSE = 0.3f;
    private float SOUND_FEEDBACK_PORTAL = 0.4f;
    private float SOUND_LEVEL = 0.2f;
    private float SOUND_MIN = 0f;

    private float soundFeedBackSaut;
    private float soundFeedBackAttract;
    private float soundFeedBackRepulse;
    private float soundFeedBackPortal;
    private float soundLevel;

    private AudioSource musicSource;
    public static SoundManager instance = null;

    public AudioClip JumpSound;
    public AudioClip AttiranceSound;
    public AudioClip RepulsionSound;
    public AudioClip PortalSound;

    public AudioClip musicLevel0;
    public AudioClip musicLevel1;
    public AudioClip musicLevel2;
    public AudioClip musicLevel3;
    public AudioClip musicLevel4;
    public AudioClip musicLevel5;


    public Toggle m_Toggle;
    bool onOff=true;
    private bool soundLevelStart = false;
    private bool mainMenu = true;

    public void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            PlaySoundLevel();
            soundLevelStart = true;

        }

    }

    public void Update()
    {
        Debug.Log("soundLevelStart" + soundLevelStart);
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (!soundLevelStart)
            {
                soundLevelStart = true;
                PlaySoundLevel();
            }
        }

        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (m_Toggle == null)
            {
                m_Toggle = GameObject.FindGameObjectWithTag("ToggleSound").GetComponent<Toggle>();
                m_Toggle.onValueChanged.AddListener(delegate {
                    ToggleValueChanged(m_Toggle);
                });
            }
            if (onOff)
            {
                m_Toggle.isOn = true;
            }
            else
            {
                m_Toggle.isOn = false;
            }
        }

        

        if (m_Toggle != null)
        {
            if (m_Toggle.isOn)
            {
                soundFeedBackSaut = SOUND_FEEDBACK_SAUT;
                soundFeedBackAttract = SOUND_FEEDBACK_ATTRACT;
                soundFeedBackRepulse = SOUND_FEEDBACK_REPULSE;
                soundFeedBackPortal = SOUND_FEEDBACK_PORTAL;
                soundLevel = SOUND_LEVEL;
            }
            if (!m_Toggle.isOn)
            {
                soundFeedBackSaut = SOUND_MIN;
                soundFeedBackAttract = SOUND_MIN;
                soundFeedBackRepulse = SOUND_MIN;
                soundFeedBackPortal = SOUND_MIN;
                soundLevel = SOUND_MIN;
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
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().PlayOneShot(JumpSound, soundFeedBackSaut);
                break;
            case "attiranceSound":
                GetComponent<AudioSource>().loop = true;
                GetComponent<AudioSource>().PlayOneShot(AttiranceSound, soundFeedBackAttract);
                break;
            case "repulsionSound":
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().PlayOneShot(RepulsionSound, soundFeedBackRepulse);
                break;
            case "portalSound":
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().PlayOneShot(PortalSound, soundFeedBackPortal);
                break;
        }

    }

    public void PlaySoundLevel()
    {
        int rand = Random.Range(0, 6);
        switch (rand)
        {
            case 0:
                GetComponent<AudioSource>().PlayOneShot(musicLevel0, soundLevel);
                break;
            case 1:
                GetComponent<AudioSource>().PlayOneShot(musicLevel1, soundLevel);
                break;
            case 2:
                GetComponent<AudioSource>().PlayOneShot(musicLevel2, soundLevel);
                break;
            case 3:
                GetComponent<AudioSource>().PlayOneShot(musicLevel3, soundLevel);
                break;
            case 4:
                GetComponent<AudioSource>().PlayOneShot(musicLevel4, soundLevel);
                break;
            case 5:
                GetComponent<AudioSource>().PlayOneShot(musicLevel5, soundLevel);
                break;
        }
    }

    public void StopSoundLevel()
    {
        GetComponent<AudioSource>().Stop();
        soundLevelStart = false;
    }

    public void ToggleValueChanged(Toggle change)
    {
        if (change.isOn)
        {
            soundFeedBackSaut = SOUND_FEEDBACK_SAUT;
            soundFeedBackAttract = SOUND_FEEDBACK_ATTRACT;
            soundFeedBackRepulse = SOUND_FEEDBACK_REPULSE;
            soundFeedBackPortal = SOUND_FEEDBACK_PORTAL;
            soundLevel = SOUND_LEVEL;
            onOff = true;
        }
        else
        {
            soundFeedBackSaut = SOUND_MIN;
            soundFeedBackAttract = SOUND_MIN;
            soundFeedBackRepulse = SOUND_MIN;
            soundFeedBackPortal = SOUND_MIN;
            soundLevel = SOUND_MIN;
            onOff = false;
        }
    }
}
