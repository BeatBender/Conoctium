using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private void OnCollisionEnter(Collision coli)
	{
		if(coli.gameObject.tag == "Player2" || coli.gameObject.tag == "Player1")
		{
			coli.gameObject.GetComponent<Player>().SetSpawnPos (coli.gameObject.GetComponent<Transform> ().position);
            //this.SpawnPos = gameObject.GetComponent<Transform>().position;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
	// Update is called once per frame
	void Update () {
		
	}
}
