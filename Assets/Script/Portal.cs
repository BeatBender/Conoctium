using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour {

    public GameObject Target;
    private static bool bJustTP;
    private PlayerMove Player;

    private Vector3 LastImpulsion;

    void Awake()
    {
        bJustTP = false;
    }


    IEnumerator OnTriggerEnter(Collider other)
    {
        Player = other.GetComponent<PlayerMove>();

        if(Target)
        {
            // if the object is tagged player
            if (other.tag == "Player" && !bJustTP)
            {
                bJustTP = true;
                // modify its transform
                other.gameObject.transform.position = Target.transform.position;

                Debug.Log("Move direction : " + Player.PlayerMoveDirection);

                PlayerMove CurrentPlayer = other.GetComponent<PlayerMove>();
                LastImpulsion = Rotate2DVector(Player.PlayerMoveDirection, Target.transform.eulerAngles.z);

                Debug.Log("impulsion : " + LastImpulsion);
                
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

    private void Update()
    {
        if(bJustTP)
        {
            Player.GetPlayerController().Move(LastImpulsion * Time.deltaTime);
        }   
    }
}
