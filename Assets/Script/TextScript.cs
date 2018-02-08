using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TextScript : MonoBehaviour {

	private int i=0;
	private int min;
	private int sec;
	public Text TimeText;
	public Text otherText1;
	public Text otherText2;
	public Text RankText;
	private int nbmax = 80;

	// Use this for initialization
	void Start () {
		StartCoroutine(Timetext());
	}

	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Timetext () {
		GameObject.FindGameObjectWithTag("NewGameButton").GetComponent<Button>().interactable=false;
		while (i != nbmax) {
			if (sec == 60) {

				min++;
				sec= 0;
			}
			yield return new WaitForSeconds (0.0001f);
			sec++;
			TimeText.text = min.ToString()+" : "+sec.ToString();
			i++;
		}
		int rand1 = Random.Range(0,200); 
		int rand2 = Random.Range(0,200); 
		for(i=0;i<rand1;i++) {
			yield return new WaitForSeconds (0.0001f);

			otherText1.text = i.ToString();
	}

		for(i=0;i<rand2;i++) {
			yield return new WaitForSeconds (0.0001f);

			otherText2.text = i.ToString();
		}


		if (nbmax >= 0 && nbmax <= 100) {
			RankText.text = " A ";
		}
		else if (nbmax >= 101 && nbmax <= 200) {
			RankText.text = " B ";
		}
		else if (nbmax >= 201) {
			RankText.text = " C ";
		}
		GameObject.FindGameObjectWithTag("NewGameButton").GetComponent<Button>().interactable=true;
		GameObject.FindGameObjectWithTag("NewGameButton").GetComponent<Button>().Select(); 

}

	public void LoadSceneBtn(string level)
	{

		SceneManager.LoadScene(level);

	}

}