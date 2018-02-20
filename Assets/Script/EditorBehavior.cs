using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditorBehavior : MonoBehaviour {

	public Canvas canvas;
	public ScrollRect selectionMenu;
	public GameObject grid;
	public EventSystem eventSystem;
    public GameObject tuto;

	enum State {SelectionState, GridState};
	State currentState = State.SelectionState;
	Vector3 currentGridPosition = new Vector3(0, 0, 0);
	GameObject currentObj = null;

	void Update () {
		////Input Management
		if (Input.GetButtonDown ("EditorSwitchInterface")) {
			switchStates ();
		}

        if(Input.GetButtonDown ("EnableTuto")){
            tuto.SetActive(!tuto.activeInHierarchy);
        }

		if(Input.GetButtonDown ("Fire1Player1")){
			if (currentObj) {
				//if the cursor is holding an object


				currentObj = null;
			} else {
			
			}
		}

		if (Input.GetAxis ("ArrowRL") != 0 || Input.GetAxis ("ArrowUD") != 0) {
			moveObject (Input.GetAxis ("ArrowRL"), Input.GetAxis ("ArrowUD"));
		}

		if(currentState == State.GridState && Input.GetAxis("HorizontalPlayer1") > 0){
			 
		}
	}

	void switchStates(){
		//Needs to be set active before in order to be able to select a button
		selectionMenu.gameObject.SetActive (currentState == State.GridState);

		if (currentState == State.GridState) {
			currentState = State.SelectionState;
			eventSystem.SetSelectedGameObject (null);
			eventSystem.SetSelectedGameObject (selectionMenu.content.GetChild(0).gameObject);
		} else {
			currentState = State.GridState;
		}
			
	}

	void moveObject(float x, float y){
		currentObj.GetComponent <Transform> ().position = new Vector3 (currentObj.GetComponent <Transform> ().position.x + x, currentObj.GetComponent <Transform> ().position.y + y, currentObj.GetComponent <Transform> ().position.z);
	}

	public void selectPrefab(GameObject prefab){
		switchStates ();
		currentObj = Instantiate (prefab);
		currentObj.GetComponent <Transform> ().position = currentGridPosition;
	}
}
