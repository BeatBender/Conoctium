using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Toggle m_Toggle;
    bool onOff = true;
    private bool soundLevelStart = false;
    private bool mainMenu = true;

    public void Start()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            PlaySoundLevel();
        }
        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            m_Toggle = GameObject.FindGameObjectWithTag("ToggleSound").GetComponent<Toggle>();
            
            //Add listener for when the state of the Toggle changes, to take action
            m_Toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(m_Toggle);
            });
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

        else if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            if (m_Toggle == null){
                m_Toggle = GameObject.FindGameObjectWithTag("ToggleSound").GetComponent<Toggle>();
            }
            Debug.Log("test2" + m_Toggle.isOn);
            if (onOff)
            {
                Debug.Log("test3" + m_Toggle.isOn);
                m_Toggle.isOn = true;
            }
            else
            {
                Debug.Log("test4" + m_Toggle.isOn);
                m_Toggle.isOn = false;
            }
        }
        if (onOff)
        {
            soundFeedBack = 0.5F;
            soundLevel = 0.05F;
        }
        else
        {
            soundFeedBack = 0F;
            soundLevel = 0F;
        }
    }

    void Awake()
    {
        Debug.Log("test");
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

    public void SoundOnOff(bool value)
    {
        if(value){
            soundFeedBack = 1F;
            soundLevel = 0.05F;
            Debug.Log(value);
        }
        else
        {
            soundFeedBack = 0F;
            soundLevel = 0F;

            Debug.Log(value);
        }
    }

    public void ToggleValueChanged(Toggle change)
    {
        if (change.isOn)
        {
            soundFeedBack = 1F;
            soundLevel = 0.05F;
            onOff = true;
        }
        else
        {
            soundFeedBack = 0F;
            soundLevel = 0F;
            onOff = false;
        }
        Debug.Log("test"+onOff);
    }
}
