using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {

    public GameObject Target;
    private static bool bJustTP;

    void Awake()
    {
        bJustTP = false;
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if(Target)
        {
            // if the object is tagged player
            if (other.tag == "Player" && !bJustTP)
            {
                bJustTP = true;
                // modify its transform
                other.gameObject.transform.position = Target.transform.position;
                other.gameObject.transform.rotation = Target.transform.rotation;

                PlayerMove CurrentPlayer = other.GetComponent<PlayerMove>();
                Vector3 ImpulseDirection = Rotate2DVector(CurrentPlayer.PlayerMoveDirection, Target.transform.eulerAngles.z);

                CurrentPlayer.GiveImpulsion(ImpulseDirection);

                yield return new WaitForSeconds(0.2f);
                bJustTP = true;
            }
        }
    }

    IEnumerator OnTriggerExit(Collider other)
    {
        if (bJustTP)
        {
            bJustTP = true;
            yield return new WaitForSeconds(0.2f);
            bJustTP = false;
        }
    }

    private Vector3 Rotate2DVector(Vector3 Vector, float Angle)
    {
        float VectorMagnitude = Vector.magnitude;
        return new Vector3(VectorMagnitude * Mathf.Cos(Angle), VectorMagnitude * Mathf.Sin(Angle), Vector.z);
    }
}
