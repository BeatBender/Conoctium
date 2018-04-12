using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButtonEditor : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
        SpawnLoadButtons();
    }

    public void SpawnLoadButtons()
    {
        int numSave;

        if (!Int32.TryParse(System.IO.File.ReadAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt"), out numSave))
        {
            numSave = 0;
            System.IO.File.WriteAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt", (0).ToString());
        }

        for (int i = 1; i <= numSave; i++)
        {
            GameObject button = Instantiate(Resources.Load("prefabEditorButton") as GameObject);
            button.GetComponent<Transform>().SetParent(this.GetComponent<Transform>(), true);
            button.GetComponent<LoadEditorLevel>().SetParamArrayAttribute(i);
            button.GetComponentInChildren<Text>().text = "Level " + i;

            String path = Application.dataPath + @"\Resources\SavesMap\map" + i + ".png";
            Byte[] bytes = System.IO.File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(1, 1);
            texture.LoadImage(bytes, false);
            Sprite image = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1f);
            button.GetComponentsInChildren<Image>()[1].sprite = image;
            //button.GetComponent<Image>().sprite = image;

            button.GetComponent<Transform>().localScale = new Vector3(1.53f, 1.11f, 1);

            if (i % 2 != 0)
                button.GetComponent<Transform>().localPosition = new Vector3(300, 863 - (370 * (i / 2)), 0);
            else
                button.GetComponent<Transform>().localPosition = new Vector3(-178, 863 - (370 * (i / 2)), 0);
        }
    }

    public void SpawnDeleteButtons()
    {
        int numSave;

        Int32.TryParse(System.IO.File.ReadAllText(Application.dataPath + @"\Resources\Saves\SaveFile.txt"), out numSave);

        for (int i = 1; i <= numSave; i++)
        {
            GameObject suppr = Instantiate(Resources.Load("btn_suppr_petit") as GameObject);
            suppr.GetComponent<Transform>().SetParent(this.GetComponent<Transform>(), true);
            suppr.GetComponent<LoadEditorLevel>().SetParamArrayAttribute(i);
            suppr.GetComponent<Transform>().localScale = new Vector3(1.5f, 1.5f, 1);

            if (i % 2 != 0)
                suppr.GetComponent<Transform>().localPosition = new Vector3(450, 1013 - (370 * (i / 2)), 0);
            else
                suppr.GetComponent<Transform>().localPosition = new Vector3(-28, 1013 - (370 * (i / 2)), 0);
        }
        
    }
	
}
