using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hooked : MonoBehaviour {

	private bool playerOne = false;
	private bool playerTwo = false;
	private Vector3 freezePosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (playerOne && Input.GetButtonDown("Fire1" + GameObject.FindGameObjectsWithTag("Player1")[0].tag))
		{
			playerOne = false;
		}
		else if(playerOne)
		{
			GameObject.FindGameObjectsWithTag("Player1")[0].transform.position = this.freezePosition;

		}
		else if (playerTwo && Input.GetButtonDown("Fire1" + GameObject.FindGameObjectsWithTag("Player2")[0].tag))
		{
			playerTwo = false;
		}
		else if(playerTwo)
		{
			GameObject.FindGameObjectsWithTag("Player1")[0].transform.position = this.freezePosition;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player1")
        {
			this.freezePosition = GameObject.FindGameObjectsWithTag("Player1")[0].transform.position;
            this.playerOne = true;
        }
	}
}
