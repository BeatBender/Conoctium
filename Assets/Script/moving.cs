using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour {
    private bool flag = false;
    public float speed = 5f;
    int i=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        while(flag)
        {
            if (i < 1000)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
                i++;
            }
        }
       
       
        
        
        
	}
}
