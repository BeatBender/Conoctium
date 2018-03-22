using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interrupteur : MonoBehaviour {
    public bool interrupteur;


    public GameObject Porte;

    private void OnCollisionEnter(Collision collision)
    {
        if(interrupteur)
        {
            if(collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" )
            {
                Destroy(Porte);
                Destroy(gameObject);
            }
        }	          
    }
}
