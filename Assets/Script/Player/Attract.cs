using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attract : MonoBehaviour {

    // A reference to the player move script for the character controller use
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
        AttractionForceIntensity = 50.0f;
    }
	
	// Update is called once per frame
	void Update () {
        switch(Player.GetPlayerIndex())
        {
            case 1:
                if(Input.GetButton("AttractKP1"))
                {
                    // Use directly the move function of the character controller to priorize this movement
                    Player.GetPlayerController().Move(GetDirectionTowardTarget() * AttractionForceIntensity * Time.deltaTime);
                }
                break;
            case 2:
                if (Input.GetButton("AttractKP2"))
                {
                    // Use directly the move function of the character controller to priorize this movement
                    Player.GetPlayerController().Move(GetDirectionTowardTarget() * AttractionForceIntensity * Time.deltaTime);
                }
                break;

            default:
                Debug.Log("Player index non initialized !");
                break;
        }
	}

    // Calculate the direction toward the target
    private Vector3 GetDirectionTowardTarget()
    {
        return Vector3.Normalize(transform.position - Target.transform.position);
    }
}
