using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

    public GameObject menuObject;
	public Transform ceiling;
	public Transform ground;
	public Transform leftWall;
	public Transform rightWall;
	public GameObject grid;
    public GameObject player1;
    public GameObject player2;
    public GameObject serialize;
    private bool isActive = false;

	private float[,] dim = new float[,]{{25, 19, 11, 0}, {35, 29, 16, 5}, {45, 39, 22, 10}};

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

	public void SetSize(int size){
		//Ceiling
		ceiling.localPosition = new Vector3(0, dim[size, 1] + 1, 0);
		ceiling.localScale = new Vector3(dim[size, 0] + 2, 1, 1);
		//Ground
		ground.localScale = new Vector3(dim[size, 0] + 2, 1, 1);
		//Left Wall
		leftWall.localPosition = new Vector3(-(dim[size, 0] + 1)/2, (dim[size, 1] + 1)/2, 0);
		leftWall.localScale= new Vector3(1, dim[size, 1] + 2, 1);
		//Right Wall
		rightWall.localPosition = new Vector3((dim[size, 0] + 1)/2, (dim[size, 1] + 1)/2, 0);
		rightWall.localScale = new Vector3(1, dim[size, 1] + 2, 1);
		//Grid
		grid.GetComponent<SpriteRenderer>().size = new Vector2(dim[size, 0], dim[size, 1]);
		grid.GetComponent<Transform> ().localPosition = new Vector3 (0, (dim[size, 1] + 1)/2, 0);
		//Camera
		this.GetComponent<Transform>().position = new Vector3(0, dim[size, 3], -30);
		this.GetComponent<Camera>().orthographicSize = dim[size, 2];
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