using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditorBehavior : MonoBehaviour {
    public GameObject serialize;
	public Canvas canvas;
	public ScrollRect selectionMenu;
	public GameObject grid;
	public EventSystem eventSystem;
    public GameObject tuto;
	public GameObject cursor;

	enum State {SelectionState, GridState};
	State currentState = State.SelectionState;
	Vector3 currentGridPosition = new Vector3(0, 0, -0.9f);
	GameObject currentObj = null;
	float actionTime = 0.0f;
	float actionCoolDown = 0.1f;

	void Awake(){
		eventSystem.SetSelectedGameObject (selectionMenu.content.GetChild(0).gameObject);
	}

	void Update () {
		////Input Management
		if (Input.GetButtonDown ("EditorSwitchInterface")) {
			switchStates ();
		}

        if(Input.GetButtonDown ("EnableTuto")){
            tuto.SetActive(!tuto.activeInHierarchy);
        }

		if(Input.GetButtonDown ("Fire1Player1")){
			if (currentState == State.GridState) {
				if (currentObj) {
					//if the cursor is holding an object
					showCursor(true);

					currentObj = null;
				} else {
					//Selection
					RaycastHit hit;
					if (Physics.Raycast (cursor.GetComponent<Transform> ().position, Vector3.forward, out hit)) {
						if (hit.collider.GetComponent<Transform> ().parent == serialize.GetComponent<Transform> ()) {
							currentObj = hit.collider.gameObject;
							showCursor (false);
						}
					}
				}
			} else {
				eventSystem.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke ();
			}
		}

		if(Input.GetButtonDown ("FireB")){
			if (currentState == State.GridState) {
				if (currentObj) {
					//if the cursor is holding an object
					Destroy(currentObj);
					showCursor(true);
					currentObj = null;
				} else {
					//Selection
					RaycastHit hit;
					if (Physics.Raycast (cursor.GetComponent<Transform> ().position, Vector3.forward, out hit)) {
						if (hit.collider.GetComponent<Transform> ().parent == serialize.GetComponent<Transform> ()) {
							Destroy(hit.collider.gameObject);
						}
					}
				}
			}
		}

		//Moving the selected object around /Keyboard
		if ((Input.GetAxis ("ArrowRL") != 0 || Input.GetAxis ("ArrowUD") != 0) && actionTime < Time.time && currentState == State.GridState) {
			moveObject (Input.GetAxis ("ArrowRL"), Input.GetAxis ("ArrowUD"));
			actionTime = Time.time + actionCoolDown;
		}

		//Moving the selected object around /Controller
		if ((Input.GetAxis ("HorizontalPlayer1") != 0 || Input.GetAxis ("VerticalPlayer1") != 0) && actionTime < Time.time && currentState == State.GridState) {
			moveObject (Mathf.RoundToInt(Input.GetAxis ("HorizontalPlayer1")), Mathf.RoundToInt(Input.GetAxis ("VerticalPlayer1")));
			actionTime = Time.time + actionCoolDown;
		}

		//Scaling the selected object
		if ((Input.GetAxis ("ScaleX") != 0 || Input.GetAxis ("ScaleY") != 0) && actionTime < Time.time && currentObj && currentState == State.GridState) {
			scaleObject (Input.GetAxis ("ScaleX"), Input.GetAxis ("ScaleY"));
			actionTime = Time.time + actionCoolDown;
		}
        if (Input.GetAxis("TriggerPlayer1") >= .8)
        {
            rotateObject(.5f);
        }

        if (Input.GetAxis("TriggerPlayer1") <= -.8)
        {
            rotateObject(-.5f);
        }

        if (currentState == State.GridState && Input.GetAxis("HorizontalPlayer1") > 0){
			 
		}
	}

	void switchStates(){
		//Needs to be set active before in order to be able to select a button
		selectionMenu.gameObject.SetActive (currentState == State.GridState);

		if (currentState == State.GridState) {
			currentState = State.SelectionState;
			eventSystem.SetSelectedGameObject (null);
			eventSystem.SetSelectedGameObject (selectionMenu.content.GetChild(0).gameObject);
			showCursor (false);
		} else {
			currentState = State.GridState;
			if (!currentObj) {
				
			}
		}
			
	}

	void moveObject(float x, float y){
		currentGridPosition.x += x;
		currentGridPosition.y += y;
		if (currentObj) {
			currentObj.GetComponent <Transform> ().position = currentGridPosition;
		} else {
			showCursor (true);
		}
	}

    void scaleObject(float x, float y)
    {
        //Influence chart: x -> z; y -> y
        Vector3 temp = currentObj.GetComponent<Transform>().localScale;
        if (temp.z + x != 0)
        {
            temp.z += x;
        }
        if (temp.y + y != 0)
        {
            temp.y += y;
        }
        currentObj.GetComponent<Transform>().localScale = temp;
    }

	void showCursor(bool value){
		cursor.SetActive (value);
		cursor.GetComponent <Transform> ().position = new Vector3(currentGridPosition.x, currentGridPosition.y, -1.5f);
	}

    void rotateObject(float x)
    {
        currentObj.GetComponent<Transform>().Rotate(new Vector3(x, 0, 0));
    }

    public void selectPrefab(GameObject prefab){
		switchStates ();
		currentObj = Instantiate (prefab);
		currentObj.GetComponent <Transform> ().position = currentGridPosition;
        currentObj.GetComponent<Transform>().parent = serialize.GetComponent<Transform>();
	}
}
