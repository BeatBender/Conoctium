using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTetureSetup : MonoBehaviour {

	public Transform planeA;
	public Camera cameraA;
	public Camera cameraB;
	public Transform planeB;
	public Material cameraMatA;
	public Material cameraMatB;

	//float width = planeA.GetComponent<Collider>.bounds.size.x;
	//float height = planeA.GetComponent<Collider>.bounds.size.y;

	// Use this for initialization
	void Start () {
		if(cameraA.targetTexture != null){
			cameraA.targetTexture.Release();
		}
		Debug.Log (Screen.width);
		Debug.Log (Screen.height);
		cameraA.targetTexture = new RenderTexture(Screen.width, Screen.height, 200);
		cameraMatA.mainTexture = cameraA.targetTexture;

		if(cameraB.targetTexture != null){
			cameraB.targetTexture.Release();
		}
		cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 0);
		cameraMatB.mainTexture = cameraB.targetTexture;
	}
}
