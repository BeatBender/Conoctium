using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingBox : MonoBehaviour {
    public float rotationSpeed;
	public Rigidbody bodyToRotate;
	Vector3 m_EulerAngleVelocity;

	// Use this for initialization
	void Start () {
        m_EulerAngleVelocity = new Vector3(0, 0, 100);
	}
	
	void FixedUpdate () {
	   Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * m_EulerAngleVelocity * Time.deltaTime);
        bodyToRotate.MoveRotation(bodyToRotate.rotation * deltaRotation);

	}
}
