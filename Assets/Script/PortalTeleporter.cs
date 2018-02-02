using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public Transform player;
	public Transform receiver;

	private bool playerIsOverlapping = false;
	
	// Update is called once per frame
	void Update () {
		if(playerIsOverlapping){

			Vector3 PortalToPlayer = player.position - transform.position;
			float dotProduct = Vector3.Dot (transform.up, PortalToPlayer);

			//if the player is 90 degrees to the portal, the cosinus is equal to 0
			//if true  the player has moved across the portal
			if(dotProduct < 0f) {
				//teleport him
				float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
				rotationDiff += 180;
				player.Rotate(Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, 0f, 0f) * PortalToPlayer;
				player.position = receiver.position + positionOffset;

				playerIsOverlapping = false;
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player1") {
			playerIsOverlapping = true;
			Debug.Log ("is trigger enter");
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.tag == "Player1"){
			playerIsOverlapping = false;
			Debug.Log ("is trigger exit");
		}
	}
}
