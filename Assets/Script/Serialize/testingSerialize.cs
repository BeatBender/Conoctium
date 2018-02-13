using Newtonsoft.Json;
using serialize;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingSerialize : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /*Cube billy = new Cube(new Vector3(6,6,6), new Vector3(7, 7, 7), new Vector3(8, 8, 8));
        //billy.serialize();
        SceneSerializer scene = new SceneSerializer();
        scene.cubes.Add(billy);
        var jsonString = JsonConvert.SerializeObject(scene);
        Debug.Log(jsonString);
        System.IO.File.WriteAllText(@"Assets\Saves\JSON.txt", jsonString);*/

        string fileName = "JSON";
        string text = System.IO.File.ReadAllText(@"Assets\Saves\" + fileName + ".txt");
        SceneSerializer scene = JsonConvert.DeserializeObject<SceneSerializer>(text);


        Debug.Log(scene.cubes.ToArray()[0].GetPos().ToString());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
