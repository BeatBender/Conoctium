using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBox : MonoBehaviour {
    public float rotationSpeed;
	public Rigidbody bodyToRotate;
	Vector3 m_EulerAngleVelocity;
	public bool changeDirection;
	int coef = 1;

	// Use this for initialization
	void Start () {
		m_EulerAngleVelocity = new Vector3(0, 0, 100);
		if(changeDirection) {
			coef = -1;
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Quaternion deltaRotation = Quaternion.Euler(coef * rotationSpeed * m_EulerAngleVelocity * Time.deltaTime);
		//1 for right or 0 for left
		bodyToRotate.MoveRotation(bodyToRotate.rotation * deltaRotation);
	}
}
