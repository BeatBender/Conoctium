using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This script aim to manage the input from the player and trigger the movement function.
 * Do not forget to assign a player index in the editor when you add a player prefab to a level
 */

public class PlayerMove : MonoBehaviour
{
    // The index of the player to differenciate both player
    public int IndexPlayer = 0;

    protected CharacterController PlayerController;

    // The speed of the player movement 
    public float PlayerMoveSpeed;

    // The player is allowed to move a little less in the air, this value tell how much the player is lowered 
    public float PlayerFactorReductionSpeedInAir;

    public float PlayerJumpSpeed;

    // The current gravity applied to the player*/
    [SerializeField]
    private Vector3 CurrentGravity;

    // The default value of the gravity pushing the player down
    protected float DefaultGravityIntensity;

    // The current direction movement of the player
    public Vector3 PlayerMoveDirection;

    public AudioClip JumpSound;

    public void Awake()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    // Use this for initialization
    public void Start()
    {
        // Initializes the gravity and the direction of the movement for the character controller 
        PlayerMoveDirection = Vector3.zero;
        DefaultGravityIntensity = 10.0f;
        CurrentGravity = Vector3.down * DefaultGravityIntensity;

        PlayerMoveSpeed = 20.0f;
        PlayerJumpSpeed = 2.50f;
        PlayerFactorReductionSpeedInAir = 0.8f;
    }


    //--------------------------------------------------------------------------//
    //--------------------------------------------------------------------------//
    public void Update()
    {
        switch (IndexPlayer)
        {
            case 1:
                // Handle the jump for the second player
                if (Input.GetButtonDown("JumpKP1"))
                {
                    if (PlayerController.isGrounded)
                    {
                        Jump();
                    }
                }
                // Handle the horizontal input of the player 1
                if (PlayerController.isGrounded)
                {
                    // Call the moveright function with the value given by horizontalkp1 input
                    float JMove = Input.GetAxis("HorizontalJP1");
                    float KMove = Input.GetAxis("HorizontalKP1");
                    float HorizontalMove = (Mathf.Abs(JMove) >= Mathf.Abs(KMove)) ? JMove : KMove;
                    MoveRight(HorizontalMove);
                }
                else
                {
                    // In air the player can move with a reduction of movement
                    float JMove = Input.GetAxis("HorizontalJP1");
                    float KMove = Input.GetAxis("HorizontalKP1");
                    float HorizontalMove = (Mathf.Abs(JMove) >= Mathf.Abs(KMove)) ? JMove : KMove;
                    MoveRight(HorizontalMove * PlayerFactorReductionSpeedInAir);
                }
                break;
            case 2:
                // Handle the jump for the second player
                if (Input.GetButtonDown("JumpKP2"))
                {
                    if (PlayerController.isGrounded)
                    {
                        Jump();
                    }
                }

                // Handle the horizontal input of the player 1
                if (PlayerController.isGrounded)
                {
                    float JMove = Input.GetAxis("HorizontalJP2");
                    float KMove = Input.GetAxis("HorizontalKP2");
                    float HorizontalMove = (Mathf.Abs(JMove) >= Mathf.Abs(KMove)) ? JMove : KMove ;
                    MoveRight(HorizontalMove);
                }
                else
                {
                    // In air the player can move with a reduction of movement
                    float JMove = Input.GetAxis("HorizontalJP2");
                    float KMove = Input.GetAxis("HorizontalKP2");
                    float HorizontalMove = (Mathf.Abs(JMove) >= Mathf.Abs(KMove)) ? JMove : KMove;
                    MoveRight(HorizontalMove * PlayerFactorReductionSpeedInAir);
                }
                break;

            default:
                Debug.Log("Player index non initialized !");
                break;
        }

        UpdatePlayerMovement();
    }

    //--------------------------------------------------------------------------//
    //--------------------------------------------------------------------------//

    // Function useful to change locally the gravity*/
    public void ApplyGravity(Vector3 GravityDirection)
    {
        PlayerMoveDirection.y += GravityDirection.y * Time.deltaTime;
    }

    private Vector3 ClampMoveDirection(Vector3 PlayerMoveDirectionUnclamped)
    {
        Vector3 ClampedMoveDirection = Vector3.zero;
        ClampedMoveDirection.x = Mathf.Clamp(PlayerMoveDirection.x, -10, 10);
        ClampedMoveDirection.y = Mathf.Clamp(PlayerMoveDirection.y, -1.5f, 10);
        ClampedMoveDirection.z = 0f;
        return ClampedMoveDirection;
    }

    //--------------------------------------------------------------------------//
    //--------------------------------------------------------------------------//

    // The function used when player jump, modify the PlayerMoveDirection
    public void Jump()
    {
        GetComponent<AudioSource>().PlayOneShot(JumpSound);
        PlayerMoveDirection.y = PlayerJumpSpeed;

    }
    
    //--------------------------------------------------------------------------//
    //--------------------------------------------------------------------------//

    // Same as the Jump() function, modify the PlayerMoveDirection
    public void MoveRight(float HorizontalValue)
    {
        PlayerMoveDirection.x = HorizontalValue;
    }

    private void UpdatePlayerMovement()
    {
        // Application of the gravity force passed by parameter
        ApplyGravity(CurrentGravity);

        // The function Move of the controller has to be the last function called
        PlayerController.Move(ClampMoveDirection(PlayerMoveDirection) * PlayerMoveSpeed * Time.deltaTime);
    }

    public CharacterController GetPlayerController() { return GetComponent<CharacterController>(); }
    public int GetPlayerIndex() { return IndexPlayer; }
}