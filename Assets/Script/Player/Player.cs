using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private float speed = 20.0f;
    private float jumpSpeed = 750f;

    private bool repulsion = false;
    private bool attraction = false;
    private bool isGrounded;

    private float maxSpeed = 30f;
    private float attractSpeed = 100f;
    private float repulSpeed = 1200f;

    private float solFriction = 1.1f;
    private float airFriction = 1.025f;

    private Vector3 SpawnPos = new Vector3(0, 0, 0);


    public AudioClip JumpSound;
    public AudioClip SwooshSound;

    // Use this for initialization
    void Start()
    {
        SpawnPos = gameObject.GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {

        IsGrounded();
        gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0, -10f * Time.deltaTime, 0);

        //Selection du joueur
        string select = "";

        select = gameObject.tag;

        //On récupère la vitesse actuel
        Vector3 actualVelocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);

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
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(actualVelocity.x + Input.GetAxis("Horizontal" + select) * speed * Time.deltaTime, actualVelocity.y, 0);

        //Mise à jour de la vitesse actuel
        actualVelocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);

        //■■■■■■■■■■ SAUT ■■■■■■■■■■■■
        if (Input.GetButtonDown("Fire1" + select) && isGrounded)
        {
            PlaySound(JumpSound);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(actualVelocity.x, actualVelocity.y + jumpSpeed * Time.deltaTime, 0);
        }

        //■■■■■■■■■■ ATTRACTION ■■■■■■■■■■■■
        if (Input.GetAxis("Trigger" + select) >= .5)
        {
            
            Vector3 otherPlayer;
            if (select == "Player1" )
            {
                if (attraction==false)
                {
                    PlaySound(SwooshSound);
                    attraction = true;
                }
                otherPlayer = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>().position;
            }
            else
            {
                if (attraction == false)
                {
                    PlaySound(SwooshSound);
                    attraction = true;
                }
                otherPlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>().position;
            }
            Vector3 mePlayer = gameObject.GetComponent<Transform>().position;
            Vector3 inbetween = Vector3.Normalize(otherPlayer - mePlayer);
            gameObject.GetComponent<Rigidbody>().velocity += attractSpeed * inbetween * Time.deltaTime;
            //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(actualVelocity.x, actualVelocity.y + jumpSpeed, 0);
        }
        else if (isGrounded)
        {
            attraction = false;
        }

        //■■■■■■■■■■ REPULSION ■■■■■■■■■■■■
        if (Input.GetAxis("Trigger" + select) <= -.5)
        {
            //Debug.Log (Input.GetAxis("Fire3"+select) + " Repulsion" + select);
            if (!repulsion)
            {
                Vector3 otherPlayer;
                if (select == "Player1")
                {
                    PlaySound(SwooshSound);
                    otherPlayer = GameObject.FindGameObjectWithTag("Player2").GetComponent<Transform>().position;
                }
                else
                {
                    PlaySound(SwooshSound);
                    otherPlayer = GameObject.FindGameObjectWithTag("Player1").GetComponent<Transform>().position;
                }
                Vector3 mePlayer = gameObject.GetComponent<Transform>().position;
                Vector3 inbetween = Vector3.Normalize(otherPlayer - mePlayer);
                gameObject.GetComponent<Rigidbody>().velocity -= repulSpeed * inbetween * Time.deltaTime;

                repulsion = true;
            }
        }
        else if (isGrounded)
        {
            repulsion = false;
        }
        //■■■■■■■■■■ TESTS VITESSE ■■■■■■■■■■■■
        if (gameObject.GetComponent<Rigidbody>().velocity.x > maxSpeed)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(maxSpeed, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);

        if (gameObject.GetComponent<Rigidbody>().velocity.y > maxSpeed)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, maxSpeed, gameObject.GetComponent<Rigidbody>().velocity.z);

        if (gameObject.GetComponent<Rigidbody>().velocity.z > maxSpeed)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, maxSpeed);

        if (gameObject.GetComponent<Rigidbody>().velocity.x < -maxSpeed)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-maxSpeed, gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.z);

        if (gameObject.GetComponent<Rigidbody>().velocity.y < -maxSpeed)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, -maxSpeed, gameObject.GetComponent<Rigidbody>().velocity.z);

        if (gameObject.GetComponent<Rigidbody>().velocity.z < -maxSpeed)
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x, gameObject.GetComponent<Rigidbody>().velocity.y, -maxSpeed);
    }


    private void OnCollisionEnter(Collision coli)
    {
        if (coli.gameObject.tag == "Player2" && gameObject.tag == "Player1")
        {
            int level = SceneManager.GetActiveScene().buildIndex;
            if (level >= SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            }
            else if (level == 1)
            {
                SceneManager.LoadScene("InterLevel");
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
    public void SetSpawnPos(Vector3 spwn)
    {
        SpawnPos = spwn;
    }
    private void IsGrounded()
    {
        float distanceTouch = 1f;
        //		Vector3 decal = new Vector3(0,-1,0);     

        RaycastHit hit;

        //Dessine un trait de couleur bleu si on ne touche pas le sol
        Debug.DrawRay(gameObject.GetComponent<Transform>().position, Vector3.down, Color.blue);

        //Si on touche un objet vers le bas à une distance inférieur à distanceTouch
        if (Physics.Raycast(gameObject.GetComponent<Transform>().position, Vector3.down, out hit, distanceTouch))
        {
            //Si l'objet a le tag "Sol"
            if (hit.transform.tag == "Sol")
            {
                //On dessine un trait de couleur rouge
                Debug.DrawRay(gameObject.GetComponent<Transform>().position, Vector3.down, Color.red);
                isGrounded = true;
            }
        }
        else
            isGrounded = false;
    }

<<<<<<< HEAD
=======
    private void PlaySound(AudioClip audioClip)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
>>>>>>> af07baa83ab7825ddb84aa47e2c9e3884098580c
}
