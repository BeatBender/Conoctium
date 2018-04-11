using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{

    private float SOUND_FEEDBACK = 0.5f;
    private float SOUND_LEVEL = 0.05f;
    private float SOUND_MIN = 0f;

    public float soundFeedBack;
    public float soundLevel;

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
                soundFeedBack = SOUND_FEEDBACK;
                soundLevel = SOUND_LEVEL;
            }
            if (!m_Toggle.isOn)
            {
                soundFeedBack = SOUND_MIN;
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

    public void SoundOnOff()
    {
        if (onOff)
        {
            soundFeedBack = SOUND_FEEDBACK;
            soundLevel = SOUND_LEVEL;
            onOff = false;
        }
        else
        {
            soundFeedBack = SOUND_MIN;
            soundLevel = SOUND_MIN;
            onOff = true;
        }
    }

    public void ToggleValueChanged(Toggle change)
    {
        if (change.isOn)
        {
            soundFeedBack = SOUND_FEEDBACK;
            soundLevel = SOUND_LEVEL;
            onOff = true;
        }
        else
        {
            soundFeedBack = SOUND_MIN;
            soundLevel = SOUND_MIN;
            onOff = false;
        }
    }
}
