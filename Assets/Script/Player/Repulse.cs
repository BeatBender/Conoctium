using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repulse : MonoBehaviour
{
    // A reference to the player move script for the character controller use
    private PlayerMove Player;

    // The target to be atracted to
    public GameObject Target;

    // Repulsion force intensity
    public float RepulsionForceIntensity { get; set; }


    public AudioClip SwooshSound;

    public void Awake()
    {
        Player = Target.GetComponent<PlayerMove>();
    }

    // Use this for initialization
    void Start()
    {
        RepulsionForceIntensity = -50.0f;
    }

    // Update is called once per frame
    void Update()
    {
        switch (Player.GetPlayerIndex())
        {
            case 1:
                if (Input.GetButtonDown("RepulseKP1"))
                {
                    PlaySound(SwooshSound);
                }
                else if (Input.GetButton("RepulseKP1") || Input.GetAxis("TriggerPlayer1") > 0.5f)
                {
                    // Use directly the move function of the character controller to priorize this movement
                    Player.GetPlayerController().Move(GetDirectionOppositeTarget() * RepulsionForceIntensity * Time.deltaTime);
                }
                
                break;
            case 2:
                if (Input.GetButtonDown("RepulseKP2"))
                {
                    PlaySound(SwooshSound);
                }
                else if (Input.GetButton("RepulseKP2") || Input.GetAxis("TriggerPlayer2") > 0.5f)
                {
                    // Use directly the move function of the character controller to priorize this movement
                    Player.GetPlayerController().Move(GetDirectionOppositeTarget() * RepulsionForceIntensity * Time.deltaTime);
                }
                break;

            default:
                Debug.Log("Player index non initialized !");
                break;
        }
    }

    // Calculate the direction opposite to the target
    private Vector3 GetDirectionOppositeTarget()
    {
        return Vector3.Normalize(transform.position - Target.transform.position);
    }

    private void PlaySound(AudioClip audioClip)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
