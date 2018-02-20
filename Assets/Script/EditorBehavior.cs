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
	Vector2Int currentGridPosition = new Vector2Int(0, 0);

	void Update () {
		////Input Management
		if (Input.GetButtonDown ("EditorSwitchInterface")) {
			switchStates ();
		}

        if(Input.GetButtonDown ("EnableTuto"))
        {
            tuto.SetActive(!tuto.activeInHierarchy);
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

	void selectGridSquare(){
		int index = currentGridPosition.y * 22 + currentGridPosition.x;
		grid.GetComponentsInChildren<Transform> () [index + 1].Translate(0, 0, -1);
	}
}
