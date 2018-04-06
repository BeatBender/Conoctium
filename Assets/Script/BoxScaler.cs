using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScaler : MonoBehaviour {

	public Transform ceiling;
	public Transform ground;
	public Transform leftWall;
	public Transform rightWall;
	public GameObject grid;
	public BoxCollider boxCollider;
	public Vector2Int limitWidth;
	public Vector2Int limitHeight;
	public PauseMenu pauseMenu;
	public Camera camera;

	private int width = 25;
	private int height = 19;

	private int previousWidth;
	private int previousHeight;

	float actionTime = 0.0f;
	float actionCoolDown = 0.15f;

	void Awake(){
		previousWidth = width;
		previousHeight = height;
	}

	// Update is called once per frame
	void Update () {
		//Confirm resize
		if (Input.GetButtonDown ("Fire1Player1")) {
			exitResize ();
		}

		//Cancel
		if (Input.GetButtonDown ("FireB")) {
			width = previousWidth;
			height = previousHeight;
			SetSize ();
			exitResize ();
		}

		//Scale
		if ((Input.GetAxis ("HorizontalPlayer1") != 0 || Input.GetAxis ("VerticalPlayer1") != 0) && actionTime < Time.time){
			width = (int)Mathf.Clamp ((float)width + Mathf.RoundToInt(Input.GetAxis ("HorizontalPlayer1")) * 2, (float)limitWidth [0], (float)limitWidth [1]);
			height = (int)Mathf.Clamp ((float)height + Mathf.RoundToInt(Input.GetAxis ("VerticalPlayer1")) * 2, (float)limitHeight [0], (float)limitHeight [1]);
			Debug.Log ("("+width+";"+height+")");
			SetSize ();
			actionTime = Time.time + actionCoolDown;
		}
	}

	private void SetSize(){
		//Ceiling
		ceiling.localPosition = new Vector3(0, height + 1, 0);
		ceiling.localScale = new Vector3(width + 2, 1, 1);
		//Ground
		ground.localScale = new Vector3(width + 2, 1, 1);
		//Left Wall
		leftWall.localPosition = new Vector3(-(width + 1)/2, (height + 1)/2, 0);
		leftWall.localScale= new Vector3(1, height + 2, 1);
		//Right Wall
		rightWall.localPosition = new Vector3((width + 1)/2, (height + 1)/2, 0);
		rightWall.localScale = new Vector3(1, height + 2, 1);
		//Grid
		grid.GetComponent<SpriteRenderer>().size = new Vector2(width, height);
		grid.GetComponent<Transform> ().localPosition = new Vector3 (0, (height + 1)/2, 0);
		//Camera
		camera.GetComponent<Transform>().position = new Vector3(0, (height - 20) / 2, -30);
		camera.orthographicSize = (Mathf.Max(width, height) + 2)/2;
		//Box Collider
		boxCollider.size = new Vector3(width, height, 0.2f);
		boxCollider.center = new Vector3(0, (height + 2) / 2, 0);
	}

	private void exitResize (){
		pauseMenu.ToggleResizeBox();
	}
}
