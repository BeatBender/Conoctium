using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ElevatorMove : MonoBehaviour {

    public Transform StartPos;
    public Transform EndPos;
    public float Speed;

    private float StartTime;
    private float JourneyLength;
	// Use this for initialization
	void Start () {
        StartTime = Time.time;
        JourneyLength = Vector3.Distance(StartPos.position, EndPos.position);
        Debug.Log(JourneyLength);
	}
	
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - StartTime) * Speed;
        float fracJourney = Mathf.Sin(distCovered / JourneyLength);
        Debug.Log(fracJourney);
        transform.position = Vector3.Lerp(StartPos.position, EndPos.position, (fracJourney+1) / 2);

    }
}
