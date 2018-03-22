using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButtonEditor : MonoBehaviour {
    private int ParamArrayAttribute = 0;
    // Use this for initialization
    void Start () {
        int numSave;

        Int32.TryParse(System.IO.File.ReadAllText(@"conoctium_Data\Resources\Saves\SaveFile.txt"), out numSave);

        for (int i = 1; i <= numSave; i++)
        {
            GameObject button = Instantiate(Resources.Load("prefabEditorButton") as GameObject);
            button.GetComponent<Transform>().parent = this.GetComponent<Transform>();
            ParamArrayAttribute = i;
            button.GetComponent<Button>().onClick.AddListener(LoadLeveltn);
            Debug.Log("Charge;ent de " + i +" niveaux");
            //button.GetComponent<Text>().text = "Level " + i;

            if (i % 2 != 0)
            {
                button.GetComponent<Transform>().position = new Vector3(380, -247 - 370 * (int)i / 2, 0);
            }
            else
            {
                button.GetComponent<Transform>().position = new Vector3(810, -247 - 370 * (int)i / 2, 0);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadLeveltn()
    {
        ButtonManager oui = Camera.main.GetComponent<ButtonManager>();
        int i = ParamArrayAttribute;
        oui.EditorBtn(i);
    }
}
