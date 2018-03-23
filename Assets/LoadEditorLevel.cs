using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEditorLevel : MonoBehaviour {

    private int ParamArrayAttribute = 0;

    // Use this for initialization
    void Start () {
        this.GetComponent<Button>().onClick.AddListener(LoadLeveltn);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LoadLeveltn()
    {
        ButtonManager oui = Camera.main.GetComponent<ButtonManager>();
        int i = ParamArrayAttribute;
        Debug.Log("Je charge le niveau " + i);
        oui.EditorBtn(i);
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
