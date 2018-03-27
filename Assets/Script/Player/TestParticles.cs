using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestParticles : MonoBehaviour
{

    //Particles
    private GameObject idle;
    private GameObject pattraction;
    private GameObject prepulsion;

    void Start()
    {
        //Find particle object in Player gameobject
        idle = transform.Find("Idle").gameObject;
        pattraction = transform.Find("Attraction").gameObject;
        prepulsion = transform.Find("Repulse").gameObject;

        //Default particles configs
        idle.SetActive(true);
        pattraction.SetActive(false);
        prepulsion.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            idle.SetActive(false);
            pattraction.SetActive(false);
            prepulsion.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            idle.SetActive(false);
            pattraction.SetActive(true);
            prepulsion.SetActive(false);
        }
        else
        {
            idle.SetActive(true);
            pattraction.SetActive(false);
            prepulsion.SetActive(false);
        }
    }
}

