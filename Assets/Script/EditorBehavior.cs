using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EditorBehavior : MonoBehaviour {
    public GameObject serialize;
	public Canvas canvas;
	public ScrollRect selectionMenu;
	public EventSystem eventSystem;
    public GameObject tuto;

	//State
	enum State {SelectionState, GridState};
	State currentState = State.SelectionState;

	//Selection
	public BoxCollider boundingBox;
	public GameObject cursor;
	public LineRenderer linker;
	Vector3 currentGridPosition = new Vector3(0, 0, -0.9f);
	GameObject currentObj = null;

	//Sound
	public AudioSource sourceAudio;
	public AudioClip backgroundMusic;
	public AudioClip moveClip;
	public AudioClip placeClip;
	public AudioClip deleteClip;
	public AudioClip duplicateClip;

	//Cooldown
	float actionTime = 0.0f;
	float actionCoolDown = 0.1f;

	void Awake(){
		eventSystem.SetSelectedGameObject (selectionMenu.content.GetChild(0).gameObject);
		sourceAudio.clip = backgroundMusic;
		sourceAudio.Play ();
	}

	void Update () {
		////Input Management
		if (Input.GetButtonDown ("EditorSwitchInterface")) {
			switchStates ();
		}

        if(Input.GetButtonDown ("EnableTuto")){
            tuto.SetActive(!tuto.activeInHierarchy);
        }

		if(Input.GetButtonDown ("FireA")){
			if (currentState == State.GridState) {
				if (currentObj) {
					//if the cursor is holding an object
					showCursor (true);

					currentObj = null;
					sourceAudio.PlayOneShot (placeClip);
				} else {
					//Selection
					GameObject selected = selectWithCursor();
					if (selected) {
						currentObj = selected;
						showCursor (false);
						sourceAudio.PlayOneShot (placeClip);
					}
				}
			} else {
				switchStates ();
			}
			linkObjects ();
		}

		if(Input.GetButtonDown ("FireB")){
			if (currentState == State.GridState) {
				if (currentObj && currentObj.layer != LayerMask.NameToLayer("Player")) {
					//if the cursor is holding an object
					if (currentObj.GetComponent<Transform> ().parent == serialize.GetComponent<Transform> ()) {
						Destroy (currentObj);
					} else {
						Destroy (currentObj.GetComponent<Transform> ().parent.gameObject);
					}
					showCursor(true);
					currentObj = null;
					sourceAudio.PlayOneShot (deleteClip);
				} else {
					//Selection
					GameObject selected = selectWithCursor();
					if (selected && selected.layer != LayerMask.NameToLayer("Player")) {
						if (selected.GetComponent<Transform> ().parent == serialize.GetComponent<Transform> ()) {
							Destroy (selected);
						} else {
							Destroy (selected.GetComponent<Transform> ().parent.gameObject);
						}
						sourceAudio.PlayOneShot (deleteClip);
					}
				}
			}
			linkObjects ();
		}

		if (Input.GetButtonDown ("Duplicate")) {
			if (currentState == State.GridState) {
				if (currentObj && currentObj.layer != LayerMask.NameToLayer("Player")) {
					if (currentObj.GetComponent<Transform> ().parent == serialize.GetComponent<Transform> ()) {
						selectPrefab (currentObj);
					} else {
						selectPrefab (currentObj.GetComponent<Transform> ().parent.gameObject);
					}
					sourceAudio.PlayOneShot (duplicateClip);
				} else {
					GameObject selected = selectWithCursor ();
					if (selected && selected.layer != LayerMask.NameToLayer("Player")) {
						if (selected.GetComponent<Transform> ().parent == serialize.GetComponent<Transform> ()) {
							selectPrefab (selected);
						} else {
							selectPrefab (selected.GetComponent<Transform> ().parent.gameObject);
						}
						showCursor (false);
						sourceAudio.PlayOneShot (duplicateClip);
					}
				}
			}
			linkObjects ();
		}

		//Moving the selected object around /Keyboard
		if ((Input.GetAxis ("ArrowRL") != 0 || Input.GetAxis ("ArrowUD") != 0) && actionTime < Time.time && currentState == State.GridState) {
			moveObject (Input.GetAxis ("ArrowRL"), Input.GetAxis ("ArrowUD"));
			actionTime = Time.time + actionCoolDown;
		}

		//Moving the selected object around /Controller
		if ((Input.GetAxis ("HorizontalPlayer") != 0 || Input.GetAxis ("VerticalPlayer") != 0) && actionTime < Time.time && currentState == State.GridState) {
			moveObject (Mathf.RoundToInt(Input.GetAxis ("HorizontalPlayer1")), Mathf.RoundToInt(Input.GetAxis ("VerticalPlayer1")));
			actionTime = Time.time + actionCoolDown;
		}

		//Scaling the selected object
		if ((Input.GetAxis ("ScaleX") != 0 || Input.GetAxis ("ScaleY") != 0) && actionTime < Time.time && currentObj && currentState == State.GridState && currentObj.layer != LayerMask.NameToLayer("Player")) {
			scaleObject (Input.GetAxis ("ScaleX"), Input.GetAxis ("ScaleY"));
			actionTime = Time.time + actionCoolDown;
		}

		if (Mathf.Abs(Input.GetAxis ("TriggerPlayer1")) > .9 && currentObj && actionTime < Time.time && currentObj.layer != LayerMask.NameToLayer("Player")) {
			rotateObject (Mathf.RoundToInt (Input.GetAxis ("TriggerPlayer1")) * 5);
			actionTime = Time.time + actionCoolDown / 2;
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
		} else {
			currentState = State.GridState;
		}

		showCursor (currentState == State.GridState && !currentObj);
			
	}

	void moveObject(float x, float y){
		//Reset to center if the cursor is outside the box (When scaling box)
//		if (!boundingBox.bounds.Contains (currentGridPosition))
//			currentGridPosition = new Vector3 (0, -8f, -0.9f);

		Vector3 temp = currentGridPosition;
		temp.x += x;
		temp.y += y;
		//if (boundingBox.bounds.Contains (temp)) //Limits movement to the bounds of the box
		currentGridPosition = temp;
		if (currentObj) {
			currentObj.GetComponent <Transform> ().position = currentGridPosition;
			sourceAudio.PlayOneShot (moveClip);
		} else {
			showCursor (true);
		}
		linkObjects ();
	}

    void scaleObject(float x, float y) {
        Vector3 temp = currentObj.GetComponent<Transform>().localScale;
		if (Mathf.RoundToInt(temp.x + x) != 0) {
            temp.x += x;
        }
		if (Mathf.RoundToInt(temp.y + y) != 0) {
            temp.y += y;
        }
        currentObj.GetComponent<Transform>().localScale = temp;
    }

	void showCursor(bool value){
		cursor.SetActive (value);
		cursor.GetComponent <Transform> ().position = new Vector3(currentGridPosition.x, currentGridPosition.y, -2f);
	}

    void rotateObject(float x){
        currentObj.GetComponent<Transform>().Rotate(new Vector3(0, 0, x));
    }

	GameObject selectWithCursor(){
		RaycastHit hit;
		if (Physics.Raycast (cursor.GetComponent<Transform> ().position, Vector3.forward, out hit)) {
			//if (hit.collider.GetComponent<Transform> ().parent == serialize.GetComponent<Transform> () || hit.collider.GetComponent<Transform> ().parent.parent == serialize.GetComponent<Transform> ()) {
			Debug.Log(hit.collider);
			if(hit.collider != boundingBox){
				return hit.collider.gameObject;
			}
		}
		return null;
	}

    public void selectPrefab(GameObject prefab){
		currentObj = Instantiate (prefab);
		currentObj.GetComponent <Transform> ().position = currentGridPosition;
        currentObj.GetComponent<Transform>().parent = serialize.GetComponent<Transform>();
		if (currentObj.GetComponentsInChildren<Transform> ().Length >= 3) {
			currentObj = currentObj.GetComponentsInChildren<Transform> () [1].gameObject;
		}
		linkObjects ();
	}

	void linkObjects(){
		if (!currentObj || currentObj.GetComponent<Transform> ().parent == serialize.GetComponent<Transform> ()) {
			linker.gameObject.SetActive (false);
		} else {
			linker.gameObject.SetActive (true);
			Transform[] objs = currentObj.GetComponent<Transform> ().parent.GetComponentsInChildren <Transform> ();
			linker.SetPosition (0, objs [1].position);
			linker.SetPosition (1, objs [2].position);
		}
	}
}
