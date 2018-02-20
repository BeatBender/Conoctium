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
	Vector3 currentGridPosition = new Vector3(0, 0, -0.9f);
	GameObject currentObj = null;
	float actionTime = 0.0f;
	float actionCoolDown = 0.1f;

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

		if ((Input.GetAxis ("ArrowRL") != 0 || Input.GetAxis ("ArrowUD") != 0) && actionTime < Time.time) {
			moveObject (Input.GetAxis ("ArrowRL"), Input.GetAxis ("ArrowUD"));
			actionTime = Time.time + actionCoolDown;
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
		currentGridPosition.x += x;
		currentGridPosition.y += y; 
		currentObj.GetComponent <Transform> ().position = currentGridPosition;
	}

	public void selectPrefab(GameObject prefab){
		switchStates ();
		currentObj = Instantiate (prefab);
		currentObj.GetComponent <Transform> ().position = currentGridPosition;
	}
}
