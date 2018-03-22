using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerBasic : MonoBehaviour {
    // Gerer l etat du niveau (debut, game over, game won, mort d un joueur)
    // Gerer les conditions de victoire et de defaite
    // Gerer les spawns et respawns des joueur
    [SerializeField]
    public GameObject SpawnPointJ1;
    [SerializeField]
    public GameObject SpawnPointJ2;

    public struct Checkpoint
    {
        public GameObject Emplacement;
        public bool WasActivated; 
    }

    [SerializeField]
    public List<Checkpoint> ListeCheckpointJ1;
    [SerializeField]
    public List<Checkpoint> ListeCheckpointJ2;

    // Gerer l emplacement des checkpoint

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
