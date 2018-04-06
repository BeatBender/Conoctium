using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerEditor : MonoBehaviour {
    public Material okMaterial;
    public Material notOkMaterial;

    private void Start()
    {
        //Freeze les rotations du player
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        
        //Desactive les billes
        gameObject.GetComponent<Transform>().GetChild(0).gameObject.SetActive(false);
        
    }

    //Change les materials du player si il est dans un mur ou objet
    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<Renderer>().material = notOkMaterial;
    }

    //Change les materials du player s'il n'est pas dans un mur ou objet
    private void OnCollisionExit(Collision collision)
    {
        gameObject.GetComponent<Renderer>().material = okMaterial;
    }
}
