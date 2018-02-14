using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrigneuneu : MonoBehaviour {
    public bool test = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(test)
        {
            test = false;
            ntm();
        }

	}

    public void ntm()
    {
        GameObject p1 = Instantiate(Resources.Load("bitcoin") as GameObject);
    }
}
