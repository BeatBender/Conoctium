using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMainCamera : MonoBehaviour {
    public Camera IntroCamera;
    public Camera MainCamera;

	public void SwitchToMainCamera(int TheValue)
    {
        IntroCamera.enabled = false;
        MainCamera.enabled = true;
        Debug.Log("Switch to main camera with a value of" + TheValue);
    }
}
