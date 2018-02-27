using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InoputHandlerDebug : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        detectPressedKeyOrButton();
	}

    void detectPressedKeyOrButton()
    {
        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                Debug.Log("KeyCode down: " + kcode);
        }
    }
}

