using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadinginformations : MonoBehaviour {

    /*Permet de passer des informations du menu au level editor*/

    private int levelLoad;
    private string sceneName = "Editor";

    public int LevelLoad
    {
        get
        {
            return levelLoad;
        }

        set
        {
            levelLoad = value;
        }
    }

    public void dontDestruct()
    {
        GameObject.DontDestroyOnLoad(gameObject);
    }


}
