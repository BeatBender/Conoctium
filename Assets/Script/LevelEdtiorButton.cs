using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        int numSave;

        Int32.TryParse(System.IO.File.ReadAllText(@"conoctium_Data\Resources\Saves\SaveFile.txt"), out numSave);

        for(int i = 0;i <= numSave; i++)
        {

        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
