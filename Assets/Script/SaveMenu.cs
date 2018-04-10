using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveMenu : MonoBehaviour
{
    public GameObject Serialize;
    public GameObject menuObject;
    private bool isActive = false;

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            menuObject.SetActive(true);
            Cursor.visible = true;
            //Cursor.lockstate - CursorLockMode.Confined;
            Time.timeScale = 0;
            //GameObject.FindGameObjectWithTag("Resume_btn").GetComponent<Button>().Select();

        }
        else
        {
            menuObject.SetActive(false);
            Cursor.visible = false;
            //Cursor.lockstate - CursorLockMode.locked;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown("joystick button 6"))
        {
            Resume_btn();
        }
    }

    public void Resume_btn()
    {
        isActive = !isActive;
    }

    public void LaunchSave()
    {
        int numSave = GameObject.FindGameObjectWithTag("LevelInfos").GetComponent<Loadinginformations>().LevelLoad;

        Int32.TryParse(System.IO.File.ReadAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt"), out numSave);
        
        Debug.Log("nbMap" + numSave);
        Serialize.GetComponent<SaveManager>().Save(numSave + 1);
        System.IO.File.WriteAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt", (numSave+1).ToString());
    }

    public void LaunchLoad(int numLoad)
    {
        Serialize.GetComponent<SaveManager>().Load(numLoad);
    }
}
