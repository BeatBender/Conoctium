using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBox : MonoBehaviour {
    public float rotationSpeed = 10f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Transform>().Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
	}
}
