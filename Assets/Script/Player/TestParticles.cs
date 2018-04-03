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

    private GameObject idle2;
    private GameObject pattraction2;
    private GameObject prepulsion2;

    void Start()
    {
        if (tag == "Player1")
        {
            //Find particle object in Player gameobject
            idle = transform.Find("Idle").gameObject;
            pattraction = transform.Find("Attraction").gameObject;
            prepulsion = transform.Find("Repulse").gameObject;
        }

        if (tag == "Player2")
        {
            //Find particle object in Player gameobject
            idle2 = transform.Find("Idle").gameObject;
            pattraction2 = transform.Find("Attraction").gameObject;
            prepulsion2 = transform.Find("Repulse").gameObject;
        }


        //Default particles configs
        idle.SetActive(true);
        pattraction.SetActive(false);
        prepulsion.SetActive(false);

        //Default particles configs
        idle2.SetActive(true);
        pattraction2.SetActive(false);
        prepulsion2.SetActive(false);
    }

    void Update()
    {
        if (tag == "Player1")
        {
            if (Input.GetKey(KeyCode.Q))
            {
                idle.SetActive(false);
                pattraction.SetActive(false);
                prepulsion.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.W))
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

        if (tag == "Player2")
        {
            if (Input.GetKey(KeyCode.E))
            {
                idle2.SetActive(false);
                pattraction2.SetActive(false);
                prepulsion2.SetActive(true);
            }
            else if (Input.GetKey(KeyCode.R))
            {
                idle2.SetActive(false);
                pattraction2.SetActive(true);
                prepulsion2.SetActive(false);
            }
            else
            {
                idle2.SetActive(true);
                pattraction2.SetActive(false);
                prepulsion2.SetActive(false);
            }
        }

    }
}

