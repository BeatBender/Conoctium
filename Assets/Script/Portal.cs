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
                yield return new WaitForSeconds(0.5f);
                bJustTP = true;
            }
        }
    }

    IEnumerator OnTriggerExit(Collider other)
    {
        if (bJustTP)
        {
            bJustTP = true;
            yield return new WaitForSeconds(0.5f);
            bJustTP = false;
        }
    }
}
