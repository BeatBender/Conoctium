using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject menuObject;
    public GameObject box;
    public GameObject player1;
    public GameObject player2;
    public GameObject serialize;
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
        else {
            menuObject.SetActive(false);
            Cursor.visible = false;
            //Cursor.lockstate - CursorLockMode.locked;
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick button 7"))
        {
            Resume_btn();
        }
    }

    public void Resume_btn()
    {
        isActive = !isActive;
    }

    public void LoadSceneBtn(string level)
    {
        SceneManager.LoadScene(level);
        GameObject temp = GameObject.FindGameObjectWithTag("LevelInfos");
        Destroy(temp);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

    public void SizeLittleBtn()
    {
        box.GetComponent<Transform>().localScale = new Vector3(24.6f, 0.31f, 1.4374f);
        box.GetComponent<Transform>().position = new Vector3(0f, -10.05f, -0.89f);
        this.GetComponent<Transform>().position = new Vector3(0f, 1f, -29.56f);
        player1.GetComponent<Transform>().position = new Vector3(-8.024024f, -8.876052f, -0.500054f);
        player2.GetComponent<Transform>().position = new Vector3(6.869448f, -8.790702f, -0.500010f);
    }

    public void SizeMediumBtn()
    {
        box.GetComponent<Transform>().localScale = new Vector3(32f, 0.39f, 1.4374f);
        box.GetComponent<Transform>().position = new Vector3(-4.04f, -10.05f, -0.89f);
        this.GetComponent<Transform>().position = new Vector3(-3.55f, 3f, -31f);
        player1.GetComponent<Transform>().position = new Vector3(-8.024024f, -8.876052f, -0.500054f);
        player2.GetComponent<Transform>().position = new Vector3(6.869448f, -8.790702f, -0.500010f);

    }

    public void SizeBigBtn()
    {
        box.GetComponent<Transform>().localScale = new Vector3(37f, 0.45f, 1.4374f);
        box.GetComponent<Transform>().position = new Vector3(-4.04f, -10.05f, -0.89f);
        this.GetComponent<Transform>().position = new Vector3(-3.35f, 2.8f, -38.63f);
        player1.GetComponent<Transform>().position = new Vector3(-8.024024f, -8.876052f, -0.500054f);
        player2.GetComponent<Transform>().position = new Vector3(6.869448f, -8.790702f, -0.500010f);

    }

    public void LaunchSave()
    {
        int numSave = GameObject.FindGameObjectWithTag("LevelInfos").GetComponent<Loadinginformations>().LevelLoad;
        if(numSave == 0)
        {
            Debug.Log("Nouvelle save");
            Int32.TryParse(System.IO.File.ReadAllText(@"conoctium_Data\Resources\Saves\SaveFile.txt"), out numSave);

            serialize.GetComponent<SaveManager>().Save(numSave + 1);
            System.IO.File.WriteAllText(@"conoctium_Data\Resources\Saves\SaveFile.txt", (numSave + 1).ToString());
        }
        else
        {
            Debug.Log("fichier sauvegardé : "+ numSave);
            serialize.GetComponent<SaveManager>().Save(numSave);
        }
        
    }

    public void LaunchLoad()
    {
        int numLoad = GameObject.FindGameObjectWithTag("LevelInfos").GetComponent<Loadinginformations>().LevelLoad;
        Debug.Log("fichier chargé : " + numLoad);
        serialize.GetComponent<SaveManager>().Load(numLoad);
    }


}