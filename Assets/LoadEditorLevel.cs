using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadEditorLevel : MonoBehaviour {

    public bool playable = false;

    private int ParamArrayAttribute = 0;

    // Use this for initialization
    void Start () {
        if(this.tag == "SupprButtonEditor")
            this.GetComponent<Button>().onClick.AddListener(SupprLeveltn);
        else
            this.GetComponent<Button>().onClick.AddListener(LoadLeveltn);
    }
	

    private void LoadLeveltn()
    {
        ButtonManager btn = Camera.main.GetComponent<ButtonManager>();
        int i = ParamArrayAttribute;
        if(!playable)
            btn.EditorBtn(i);
        else
            btn.EditorPlayBtn(i);
    }

    private void SupprLeveltn()
    {
        int i = ParamArrayAttribute;
        SaveManager.Delete(i);
        GameObject[] list = GameObject.FindGameObjectsWithTag("Level1btn");
        foreach (GameObject game in list)
            Destroy(game);
        GameObject.FindGameObjectWithTag("LoadButtonEditor").GetComponent<LoadButtonEditor>().SpawnLoadButtons();
        Camera.main.GetComponent<ButtonManager>().EditorSupprBtn();
        Camera.main.GetComponent<ButtonManager>().EditorSupprBtn();
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
