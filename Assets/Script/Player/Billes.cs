using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billes : MonoBehaviour {
    private Joint[] joint;
	// Use this for initialization
	void Start ()
    {
        joint = GetComponentsInChildren<Joint>();
	}
	
	// Update is called once per frame
	void Update ()
    {

	    for (int i = 0; i < joint.Length; i++)
        {
            joint[i].autoConfigureConnectedAnchor = false;
            joint[i].anchor = Vector3.zero;
            joint[i].connectedAnchor = GetComponentInParent<Transform>().position;
        }
	}
}
