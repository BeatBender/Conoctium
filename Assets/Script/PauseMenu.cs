using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    public GameObject menuObject;
    public GameObject player1;
    public GameObject player2;
    public GameObject serialize;
	public GameObject editorController;
	public Button firstButton;
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
            try
            {
                SoundManager.instance.StopSoundLevel();
            }
            catch (Exception e)
            {
                print("error" + e);
            }
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
			firstButton.Select ();
			firstButton.OnSelect (null);
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


	public void playEditor(){
		SceneManager.LoadScene("EditorPlayer", LoadSceneMode.Single);
	}

    public void LaunchSave()
    {
        int numSave = GameObject.FindGameObjectWithTag("LevelInfos").GetComponent<Loadinginformations>().LevelLoad;
        if (numSave == 0)
        {
            Int32.TryParse(System.IO.File.ReadAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt"), out numSave);
            Debug.Log("Nouvelle save : " + numSave);
            serialize.GetComponent<SaveManager>().Save(numSave + 1);
            System.IO.File.WriteAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt", (numSave + 1).ToString());

            GameObject.FindGameObjectWithTag("LevelInfos").GetComponent<Loadinginformations>().LevelLoad = numSave;
        }
        else
        {
            Debug.Log("fichier sauvegardé : " + numSave);
            serialize.GetComponent<SaveManager>().Save(numSave);
        }

    }

    public void LaunchLoad()
    {
        int numLoad = GameObject.FindGameObjectWithTag("LevelInfos").GetComponent<Loadinginformations>().LevelLoad;
        Debug.Log("fichier chargé : " + numLoad);
        serialize.GetComponent<SaveManager>().Load(numLoad);
    }

	public void ToggleResizeBox(){
		MonoBehaviour editorBehavior = editorController.GetComponent<EditorBehavior> () as MonoBehaviour;
		MonoBehaviour boxScaler = editorController.GetComponent<BoxScaler> () as MonoBehaviour;
		boxScaler.enabled = !boxScaler.enabled;
		editorBehavior.enabled = !editorBehavior.enabled;

		if(isActive)
			Resume_btn ();
	}

}