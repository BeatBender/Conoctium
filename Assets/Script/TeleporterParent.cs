using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterParent : MonoBehaviour {

	//public GameObject teleporterA;
	//public GameObject teleporterB;
	//private float adjust = 1.5f;
	//private bool jumpPlayer1;
	//private bool jumpPlayer2;
	public Color color;

	void Start () {
		//apply color to children
		Renderer[] allChildren;
		allChildren = gameObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer cpn in allChildren){
			cpn.material.color = color;
		}
	}

	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log ("is trigger enter parent");
		/*if(other.tag == "Player1" && !jumpPlayer1) {
			target.GetComponent<PortalTeleporter>().jumpPlayer1 = true;
			other.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + adjust, 0);
			Debug.Log ("TP j1");
		}
		if(other.tag == "Player2"&& !jumpPlayer2) {
			target.GetComponent<PortalTeleporter>().jumpPlayer2 = true;
			other.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + adjust, 0);
			Debug.Log ("TP j2");
		}*/
	}

	void OnTriggerExit(Collider other) {
		//Debug.Log ("is trigger exit parent");
		/*if(other.tag == "Player1"){
			jumpPlayer1 = false;
		}
		if(other.tag == "Player2"){
			jumpPlayer2 = false;
		}
		*/
	}
}
