using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBox : MonoBehaviour {
    public float rotationSpeed;
	public Rigidbody box;

	// Use this for initialization
	void Start () {
		//box = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        //box.AddForce(0, 0, rotationSpeed);
		//box.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
	}
}
