﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject menuObject;
    public GameObject box;
    public GameObject grid;
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
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }

    public void SizeLittleBtn()
    {
        box.GetComponent<Transform>().localScale = new Vector3(24.6f, 0.31f, 1.4374f);
        grid.GetComponent<LevelEditor>().resolution = 22;
    }

    public void SizeMediumBtn()
    {
        box.GetComponent<Transform>().localScale = new Vector3(37f, 0.45f, 1.4374f);
        grid.GetComponent<LevelEditor>().resolution = 24;
    }

    public void SizeBigBtn()
    {
        box.GetComponent<Transform>().localScale = new Vector3(37f, 0.45f, 1.4374f);
        grid.GetComponent<LevelEditor>().resolution = 26;
    }

		
}