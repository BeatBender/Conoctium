using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UILevel : MonoBehaviour {

    // Use this for initialization
    public Text nameLevel;
    public GameObject level;
	void Start () {
        nameLevel.text = SceneManager.GetActiveScene().name;
        StartCoroutine(enleverUi());
	}



    IEnumerator enleverUi()
    {
    
        yield return new WaitForSeconds(3);
    
        Destroy(level);

    }


}
