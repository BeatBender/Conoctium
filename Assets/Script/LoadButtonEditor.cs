﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButtonEditor : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        int numSave;

        Int32.TryParse(System.IO.File.ReadAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt"), out numSave);

        for (int i = 1; i <= numSave; i++)
        {
            GameObject button = Instantiate(Resources.Load("prefabEditorButton") as GameObject);
            button.GetComponent<Transform>().SetParent(this.GetComponent<Transform>(), true);
            button.GetComponent<LoadEditorLevel>().SetParamArrayAttribute(i);
            Debug.Log("Chargement de " + i +" niveaux");
            button.GetComponentInChildren<Text>().text = "Level " + i;

            String path = Application.dataPath + @"\Resources\SavesMap\map" + i + ".png";
            Byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes, false);
            Sprite image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
            button.GetComponent<Image>().sprite = image;

            button.GetComponent<Transform>().localScale = new Vector3(1.53f, 1.11f, 1);

            if (i % 2 != 0)
                button.GetComponent<Transform>().localPosition = new Vector3(380, 863 - (370 * (i / 2)), 0);
            else
                button.GetComponent<Transform>().localPosition = new Vector3(-178, 863 - (370 * (i / 2)), 0);
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
   
    
}
