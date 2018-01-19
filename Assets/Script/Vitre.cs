using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vitre : MonoBehaviour {
	public bool horizontal;
    public bool vertical;


    private void OnCollisionEnter(Collision collision)
    {
		float breackingSpeed = 0.11f;
		Debug.Log ("x speed " + collision.gameObject.GetComponent<Rigidbody> ().velocity.x);
		//Debug.Log ("y speed " + collision.gameObject.GetComponent<Rigidbody> ().velocity.y);
        if (horizontal)
        {
            if (Mathf.Abs(collision.gameObject.GetComponent<Rigidbody>().velocity.x) >= breackingSpeed)
            {
                gameObject.SetActive(false);
            }
        }
        if(vertical)
        {
            if (Mathf.Abs(collision.gameObject.GetComponent<Rigidbody>().velocity.y) >= breackingSpeed)
            {
                gameObject.SetActive(false);
            }
        }
                
    }
}
