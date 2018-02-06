using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {
	Animator animator;
	//GameObject btnmenu;
	//GameObject btnlevel;
	Button NewGameButton;
	bool inlevelmenu =false;
	bool inoptionsmenu =false;

	void Awake()
	{
		animator = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
	}

	void Start () {
		
	}

	void OnEnable()
	{
		Time.timeScale = 1;
	}

	public void goinSelectionMenu () {
		inlevelmenu = true;
		animator.SetTrigger("MoveMenuRight");
		StartCoroutine(toright());
	}

	public void goBackMenu () {
		if (inlevelmenu == true) {
			animator.SetTrigger ("MoveMenuLeft");
			StartCoroutine (toleft ());
			inlevelmenu = false;
		} else if (inoptionsmenu == true) {
			animator.SetTrigger ("MoveToTop");
			StartCoroutine (toleft ());
			inoptionsmenu = false;

		}

	}

	public void goOptionsMenu () {
		Debug.Log ("Options menu");
		inoptionsmenu = true;
		animator.SetTrigger("MoveToOptions");
		StartCoroutine(todown());
	}


	 IEnumerator toright () {
		GameObject.FindGameObjectWithTag("Level1btn").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("Level2btn").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("Level3btn").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("Level4btn").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("Level10btn").GetComponent<Button>().interactable=true;
		yield return new WaitForSeconds (2);

		GameObject.FindGameObjectWithTag("Backbtn").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("NewGameButton").GetComponent<Button>().interactable=false;

		GameObject.FindGameObjectWithTag("OptionsButton").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("BackOptionbtn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Level1btn").GetComponent<Button>().Select(); 

	}

	 IEnumerator toleft () {
		yield return new WaitForSeconds (1);
		GameObject.FindGameObjectWithTag("NewGameButton").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("OptionsButton").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("Level1btn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Level2btn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Level3btn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Level4btn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Level10btn").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("Backbtn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("BackOptionbtn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("NewGameButton").GetComponent<Button>().Select();

	}

	IEnumerator todown () {
		GameObject.FindGameObjectWithTag("Level1btn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Level2btn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Level3btn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Level4btn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Level10btn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("Backbtn").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("BackOptionbtn").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("BackOptionbtn").GetComponent<Button>().Select();
		yield return new WaitForSeconds (1);
		GameObject.FindGameObjectWithTag("NewGameButton").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("OptionsButton").GetComponent<Button>().interactable=false;
		GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>().interactable=false;



	}


	void Update ()
	{
		Debug.Log ("timescale = " + Time.timeScale);
	}


	public void NewGameBtn(string newGameLevel)
    {
		
        SceneManager.LoadScene(newGameLevel);

    }

    public void EditorBtn()
    {
        SceneManager.LoadScene("Editor");

    }

    public void ExitGameBtn()
    {

        Application.Quit();
    }
}
