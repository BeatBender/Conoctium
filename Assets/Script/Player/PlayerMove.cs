using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    /** The speed of the player movement */
    public float PlayerMoveSpeed;
    /** If the player is grounded */
    private bool IsGrounded;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(IsPGrounded());
	}


    /** Return true if the player is grounded on anything with a collider */
    public bool IsPGrounded()
    {
        /** Get the collider of the player*/
        Collider PlayerCollider = GetComponent<Collider>();
        if (PlayerCollider)
        {
            return Physics.Raycast(transform.position, - Vector3.up, PlayerCollider.bounds.extents.y + 0.1f);
        }
        // Return false if the object doesnt have a collider
        else { return false; }
    }
}

/*public bool SpawnPlayer(Transform NewPosition)
{
    return true;
}*/
