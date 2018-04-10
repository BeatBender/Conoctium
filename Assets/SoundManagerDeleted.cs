using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerDeleted : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        GameObject soundManager = GameObject.FindGameObjectWithTag("soundManager");
        if (soundManager != null)
        {
            soundManager.GetComponent<Transform>().SetParent(this.GetComponent<Transform>());
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
