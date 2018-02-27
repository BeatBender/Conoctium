using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterPortal : MonoBehaviour {

	public GameObject target;
	//private float adjust = 0.2f;
	private bool jumpPlayer1;
	private bool jumpPlayer2;

	void Start () {
	}

	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log ("is trigger enter");
		if(other.tag == "Player1" && !jumpPlayer1) {
		    target.GetComponent<TeleporterPortal>().jumpPlayer1 = true;
			//other.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y , 0);
            //Rigidbody p1 = other.gameObject.GetComponent<Rigidbody>();
            //float vecNorm = p1.velocity.magnitude;
            //p1.velocity = new Vector3(vecNorm * Mathf.Sin(this.transform.localRotation.z), vecNorm * Mathf.Cos(this.transform.localRotation.z), 0f);
			other.gameObject.GetComponent<Player>().Teleport(target.gameObject.GetComponent<Transform>().position);
            Debug.Log ("TP j1");
		}
		if(other.tag == "Player2" && !jumpPlayer2) {
		    target.GetComponent<TeleporterPortal>().jumpPlayer2 = true;
		    //other.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y , 0);
            //Rigidbody p2 = other.gameObject.GetComponent<Rigidbody>();
            //float vecNorm = p2.velocity.magnitude;
            //p2.velocity = new Vector3(vecNorm * Mathf.Sin(this.transform.localRotation.z), vecNorm * Mathf.Cos(this.transform.localRotation.z), 0f);
			other.gameObject.GetComponent<Player>().Teleport(target.gameObject.GetComponent<Transform>().position);
            Debug.Log ("TP j2");
		}
	}

	void OnTriggerExit(Collider other) {
		//Debug.Log ("is trigger exit");
		if(other.tag == "Player1"){
			jumpPlayer1 = false;
		}
		if(other.tag == "Player2"){
			jumpPlayer2 = false;
		}
	}
}
