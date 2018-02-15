using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour {
    private PlayerMove Player;

    // The target to be atracted to
    public GameObject Target;

    // Attraction force intensity
    public float AttractionForceIntensity { get; set; }

    public void Awake()
    {
        Player = Target.GetComponent<PlayerMove>();
    }

    // Use this for initialization
    void Start () {
        AttractionForceIntensity = 5.0f;
    }
	
	// Update is called once per frame
	void Update () {
        switch(Player.GetPlayerIndex())
        {
            case 1:
                if(Input.GetButtonDown("AttractKP1"))
                {
                    Debug.Log(GetDirectionTowardTarget());
                    GetComponent<Rigidbody>().AddForce(GetDirectionTowardTarget() * AttractionForceIntensity * 100.0f);
                }
                break;
            case 2:
                if (Input.GetButtonDown("AttractKP2"))
                {
                    GetComponent<Rigidbody>().AddForce(GetDirectionTowardTarget() * AttractionForceIntensity);
                }
                break;

            default:
                Debug.Log("Player index non initialized !");
                break;
        }
	}

    private Vector3 GetDirectionTowardTarget()
    {
        return Vector3.Normalize(transform.position - Target.transform.position);
    }
}
