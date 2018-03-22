using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : MonoBehaviour {
    private bool player1;
    private bool player2;

  
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            player1 = true;
        }
        if (collision.gameObject.tag == "Player2")
        {
            player2 = true;
        }
        Debug.Log("P1 " + player1 + "//  P2 " + player2);
        if(player1 && player2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            player1 = false;
        }
        if (collision.gameObject.tag == "Player2")
        {
            player2 = false;
        }
    }
}
