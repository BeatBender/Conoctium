using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ButtonManager : MonoBehaviour {
	Animator animator;
	//GameObject btnmenu;
	//GameObject btnlevel;
	Button NewGameButton;
	bool inlevelmenu =false;
	bool inoptionsmenu =false;
    bool inleveleditormenu = false;
    public  List<GameObject> ListLevel; 
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
             StartCoroutine (tomainmenu ());
            inoptionsmenu = false;

		}
        else if (inleveleditormenu == true)
        {
            animator.SetTrigger("MoveToMainMenu");
            StartCoroutine(todown());
            inoptionsmenu = false;

        }

    }

	public void goOptionsMenu () {
		Debug.Log ("Options menu");
		inoptionsmenu = true;
		animator.SetTrigger("MoveToOptions");
		StartCoroutine(todownoptions());
	}

    public void goLevelEditorMenu()
    {

        inleveleditormenu = true;
        animator.SetTrigger("MoveToLevelEditor");
        StartCoroutine(totop());
    }


    IEnumerator toright () {
        
        
        ListLevel[1].SetActive(true);
        ListLevel[6].SetActive(true);
        GameObject.FindGameObjectWithTag("Level1btn").GetComponent<Button>().Select();
        yield return new WaitForSeconds(1);
        ListLevel[0].SetActive(false);
       

	}

	 IEnumerator toleft () {
        ListLevel[0].SetActive(true);
        GameObject.FindGameObjectWithTag("NewGameButton").GetComponent<Button>().Select();
        yield return new WaitForSeconds(1);
        ListLevel[6].SetActive(false);
        ListLevel[1].SetActive(false);
        ListLevel[2].SetActive(false);
        ListLevel[3].SetActive(false);

    }

	IEnumerator todown () {


        ListLevel[0].SetActive(true);
        yield return new WaitForSeconds(1);
        ListLevel[4].SetActive(false);


    }

    IEnumerator todownoptions()
    {


        ListLevel[5].SetActive(true);
        GameObject.FindGameObjectWithTag("BackOptionbtn").GetComponent<Button>().Select();
        yield return new WaitForSeconds(1);
        ListLevel[0].SetActive(false);



    }


    IEnumerator tomainmenu()
    {

        
        ListLevel[0].SetActive(true);
        GameObject.FindGameObjectWithTag("NewGameButton").GetComponent<Button>().Select();
        yield return new WaitForSeconds(1);
        ListLevel[5].SetActive(false);



    }


    IEnumerator totop()
    {

        
        ListLevel[4].SetActive(true);
        GameObject.FindGameObjectWithTag("Level2btn").GetComponent<Button>().Select();
        yield return new WaitForSeconds(1);
        ListLevel[0].SetActive(false);

    }

    public void PageList(int nblevel)
    {
        int i = 0;
        foreach (GameObject page in ListLevel)
        {
            if (i == 6)
            {
                break;

            }
            page.SetActive(false);
            i++;
        }

        ListLevel[nblevel].SetActive(true);



    }


	public void NewGameBtn(string newGameLevel)
    {
		
        SceneManager.LoadScene(newGameLevel);

    }


    public void EditorBtn(int numLevel )
    {  
        //creer objet
        GameObject LevelInfos;
        LevelInfos = new GameObject();        
        LevelInfos.tag = "LevelInfos";
        LevelInfos.name = "LevelInfos";
        LevelInfos.AddComponent<Loadinginformations>();
        LevelInfos.GetComponent<Loadinginformations>().LevelLoad = numLevel;
        LevelInfos.GetComponent<Loadinginformations>().dontDestruct();

        //Load la scene editor
        SceneManager.LoadScene("Editor");
            
        var folder = Directory.CreateDirectory("conoctium_Data/Resources/Saves");
    }


    public void ExitGameBtn()
    {

        Application.Quit();
    }





}
