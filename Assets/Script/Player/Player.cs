using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 30.0f;
    [SerializeField]
    private float jumpSpeed = 750f;

    private bool repulsion = false;
    private bool attraction = false;
    private bool isGrounded;

    private float maxSpeed = 30f;
    private float attractSpeed = 100f;
    private float repulSpeed = 1200f;

    [SerializeField]
    private float solFriction = 1.1f;
    [SerializeField]
    private float airFriction = 1.025f;

    //Particles
    private GameObject idle;
    private GameObject pattraction;
    private GameObject prepulsion;

    private GameObject idle2;
    private GameObject pattraction2;
    private GameObject prepulsion2;

    private Vector3 SpawnPos = new Vector3(0, 0, 0);

    // Use this for initialization
    void Start()
    {
        SpawnPos = gameObject.GetComponent<Transform>().position;


        if (tag == "Player1")
        {
            //Find particle object in Player gameobject
            idle = transform.Find("Idle").gameObject;
            pattraction = transform.Find("Attraction").gameObject;
            prepulsion = transform.Find("Repulse").gameObject;
        }

        if (tag == "Player2")
        {
            //Find particle object in Player gameobject
            idle2 = transform.Find("Idle").gameObject;
            pattraction2 = transform.Find("Attraction").gameObject;
            prepulsion2 = transform.Find("Repulse").gameObject;
        }

        //Default particles configs
        idle.SetActive(true);
        pattraction.SetActive(false);
        prepulsion.SetActive(false);

        //Default particles configs
        idle2.SetActive(true);
        pattraction2.SetActive(false);
        prepulsion2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody gameObjRigidBody = gameObject.GetComponent<Rigidbody>();
        IsGrounded();
        gameObjRigidBody.velocity += new Vector3(0, -10f * Time.deltaTime, 0);

        //Selection du joueur
        string select = "";

        select = gameObject.tag;

        //On récupère la vitesse actuel

        Vector3 actualVelocity = new Vector3(gameObjRigidBody.velocity.x, gameObjRigidBody.velocity.y, gameObjRigidBody.velocity.z);

        if (Input.GetAxis("Horizontal" + select) == 0 && Input.GetAxis("Trigger" + select) <= 0.015 && Input.GetAxis("Trigger" + select) >= -0.015)
        {
            if (isGrounded)
                actualVelocity.x = (actualVelocity.x) / solFriction;
            else
                actualVelocity.x = (actualVelocity.x) / airFriction;
        }

        // On récupère la direction (normalisé) des joystick dans l'axe x et y
        // float horizontalMoove = Input.GetAxis("Horizontal" + select);
        // float verticalMoove = Input.GetAxis("Vertical" + select);

        //■■■■■■■■■■ MOOVE ■■■■■■■■■■■
        //On ajoute à la vitesse actuel sa propre vitesse plus celle du joystick * speed * temps entre deux frames
        gameObjRigidBody.velocity = new Vector3(actualVelocity.x + Input.GetAxis("Horizontal" + select) * speed * Time.deltaTime, actualVelocity.y, 0);

        //Mise à jour de la vitesse actuel
        actualVelocity = new Vector3(gameObjRigidBody.velocity.x, gameObjRigidBody.velocity.y, gameObjRigidBody.velocity.z);

		Debug.Log ("in boucle");
		Debug.Log (Input.GetKey(KeyCode.Space));
        //■■■■■■■■■■ SAUT ■■■■■■■■■■■■
        if (Input.GetButtonDown("Fire1" + select) && isGrounded)
        {
			Debug.Log ("jump");
            gameObjRigidBody.velocity = new Vector3(actualVelocity.x, actualVelocity.y + jumpSpeed * Time.deltaTime, 0);
			try {
				SoundManager.instance.PlaySound("jumpSound");
			}
			catch (Exception e) {
				print("error" + e);
			}  

        }

        //■■■■■■■■■■ ATTRACTION ■■■■■■■■■■■■
        if (Input.GetAxis("Trigger" + select) >= .5)
        {

            Vector3 otherPlayer;
            if (select == "Player1")
            {
                if (attraction == false)
                {
                    try
                    {
                        SoundManager.instance.PlaySound("attiranceSound");
                    }
                    catch (Exception e)
                    {
                        print("error" + e);
                    }
                    attraction = true;
                }
                otherPlayer = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>().position;
            }
            else
            {
                if (attraction == false)
                {
                    try
                    {
                        SoundManager.instance.PlaySound("attiranceSound");
                    }
                    catch (Exception e)
                    {
                        print("error" + e);
                    }
                    attraction = true;
                }
                otherPlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>().position;
            }
            Vector3 mePlayer = gameObject.GetComponent<Transform>().position;
            Vector3 inbetween = Vector3.Normalize(otherPlayer - mePlayer);
            gameObjRigidBody.velocity += attractSpeed * inbetween * Time.deltaTime;
            //gameObjRigidBody.velocity = new Vector3(actualVelocity.x, actualVelocity.y + jumpSpeed, 0);
        }
        else if (isGrounded)
        {
            attraction = false;
        }

        //■■■■■■■■■■ REPULSION ■■■■■■■■■■■■
        if (Input.GetAxis("Trigger" + select) <= -.5)
        {
            if (!repulsion)
            {
                Vector3 otherPlayer;
                if (select == "Player1")
                {
                    try
                    {
                        SoundManager.instance.PlaySound("repulsionSound");
                    }
                    catch (Exception e)
                    {
                        print("error" + e);
                    }
                    otherPlayer = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>().position;
                }
                else
                {
                    try
                    {
                        SoundManager.instance.PlaySound("repulsionSound");
                    }
                    catch (Exception e)
                    {
                        print("error" + e);
                    }
                    otherPlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>().position;
                }
                Vector3 mePlayer = gameObject.GetComponent<Transform>().position;
                Vector3 inbetween = Vector3.Normalize(otherPlayer - mePlayer);
                gameObjRigidBody.velocity -= repulSpeed * inbetween * Time.deltaTime;

                repulsion = true;
            }
        }
        else if (isGrounded)
        {
            repulsion = false;
        }
        //■■■■■■■■■■ TESTS VITESSE ■■■■■■■■■■■■
		Vector3 gameObjVelocity = gameObjRigidBody.velocity;

		if (gameObjVelocity.x > maxSpeed)
			gameObjVelocity = new Vector3(maxSpeed, gameObjVelocity.y, gameObjVelocity.z);

		if (gameObjVelocity.y > maxSpeed)
			gameObjVelocity = new Vector3(
					gameObjVelocity.x, 
					maxSpeed, 
					gameObjVelocity.z);

		if (gameObjVelocity.z > maxSpeed)
			gameObjVelocity = new Vector3(
				gameObjVelocity.x, 
				gameObjVelocity.y, 
				maxSpeed);

		if (gameObjVelocity.x < -maxSpeed)
			gameObjVelocity = new Vector3(
				-maxSpeed, 
				gameObjVelocity.y, 
				gameObjVelocity.z);

		if (gameObjVelocity.y < -maxSpeed)
			gameObjVelocity = new Vector3(
				gameObjVelocity.x, 
				-maxSpeed, 
				gameObjVelocity.z);

		if (gameObjVelocity.z < -maxSpeed)
			gameObjVelocity = new Vector3(
				gameObjVelocity.x, 
				gameObjVelocity.y, 
				-maxSpeed);

        //Changement de particules selon la bonne touche
        if (tag == "Player1")
        {
            if (repulsion)
            {
                idle.SetActive(false);
                pattraction.SetActive(false);
                prepulsion.SetActive(true);
            }
            else if (attraction)
            {
                idle.SetActive(false);
                pattraction.SetActive(true);
                prepulsion.SetActive(false);
            }
            else
            {
                idle.SetActive(true);
                pattraction.SetActive(false);
                prepulsion.SetActive(false);
            }
        }

        if (tag == "Player2")
        {
            if (repulsion)
            {
                idle2.SetActive(false);
                pattraction2.SetActive(false);
                prepulsion2.SetActive(true);
            }
            else if (attraction)
            {
                idle2.SetActive(false);
                pattraction2.SetActive(true);
                prepulsion2.SetActive(false);
            }
            else
            {
                idle2.SetActive(true);
                pattraction2.SetActive(false);
                prepulsion2.SetActive(false);
            }
        }
        //Fin changement de particules
    }


    public void OnCollisionEnter(Collision coli)
    {
        if (coli.gameObject.tag == "Player2" && gameObject.tag == "Player1")
        {
            int level = SceneManager.GetActiveScene().buildIndex;
            if (level >= SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene(level + 1, LoadSceneMode.Single);
            }
        }
        else if (coli.gameObject.tag == "Radioactive")
        {
            gameObject.GetComponent<Transform>().position = SpawnPos;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

	public void OnCollisionStay(Collider other){
		transform.parent = other.transform;
	}

	public void OnCollisionExit(Collider other){
		transform.parent = null;
	}    

    public void Teleport(Vector3 pos)
    {

        try
        {
            SoundManager.instance.PlaySound("portalSound");
        }
        catch (Exception e)
        {
            print("error" + e);
        }
        gameObject.GetComponent<Transform>().position = pos;
    }

    public void SetSpawnPos(Vector3 spwn)
    {
        SpawnPos = spwn;
    }


    void IsGrounded()
    {
        float distanceTouch = 1f;   
        RaycastHit hit;

        //Dessine un trait de couleur bleu si on ne touche pas le sol
        Debug.DrawRay(gameObject.GetComponent<Transform>().position, Vector3.down, Color.blue);

        //Si on touche un objet vers le bas à une distance inférieur à distanceTouch
		if (Physics.Raycast (gameObject.GetComponent<Transform> ().position, Vector3.down, out hit, distanceTouch)) 
		{
			//Si l'objet a le tag "Sol"
			if (hit.transform.tag == "Sol") 
			{
				//On dessine un trait de couleur rouge
				Debug.DrawRay (gameObject.GetComponent<Transform> ().position, Vector3.down, Color.red);
				isGrounded = true;
			}
		} else {
			isGrounded = false;
		}
            
    }
}

