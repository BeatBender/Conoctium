﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEditorLevel : MonoBehaviour {

    private int ParamArrayAttribute = 0;

    // Use this for initialization
    void Start () {
        if(this.tag == "SupprButtonEditor")
            this.GetComponent<Button>().onClick.AddListener(SupprLeveltn);
        else
            this.GetComponent<Button>().onClick.AddListener(LoadLeveltn);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadLeveltn()
    {
        ButtonManager btn = Camera.main.GetComponent<ButtonManager>();
        int i = ParamArrayAttribute;
        Debug.Log("Je charge le niveau " + i);
        btn.EditorBtn(i);
    }

    private void SupprLeveltn()
    {
        int i = ParamArrayAttribute;
        Debug.Log("Je Supprime le niveau " + i);
        SaveManager.Delete(i);
    }

    public int GetParamArrayAttribute()
    {
        return this.ParamArrayAttribute;
    }
    public void SetParamArrayAttribute(int newValue)
    {
        this.ParamArrayAttribute = newValue;
    }
}
