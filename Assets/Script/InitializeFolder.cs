using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeFolder : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // create the folder for save files
        var folder = Directory.CreateDirectory(Application.dataPath + "/Resources/Saves");
        //if the SaveFile do not exists create it with a value of 0
        if(!System.IO.File.Exists(Application.dataPath + "/Resources/Saves/SaveFile.txt"))
        {
            //Debug.Log("No Savce file found");
            System.IO.File.WriteAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt", "0");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
