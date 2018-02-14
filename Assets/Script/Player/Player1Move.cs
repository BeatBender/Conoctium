using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Move : MonoBehaviour
{
    protected CharacterController PlayerController;

    /** The speed of the player movement */
    public float PlayerMoveSpeed;

    /** The player is allowed to move a little less in the air, this value tell how much the player is lowered */
    public float PlayerFactorReductionSpeedInAir;

    public float PlayerJumpSpeed;

    /** The current gravity applied to the player*/
    public Vector3 CurrentGravity { get; set; }

    /** The default value of the gravity pushing the player down*/
    protected float DefaultGravityIntensity;

    // The current direction movement of the player
    protected Vector3 PlayerMoveDirection;

    public void Awake()
    {
        PlayerController = GetComponent<CharacterController>();
    }

    // Use this for initialization
    public void Start()
    {
        /** Initializes the gravity and the direction of the movement for the character controller */
        PlayerMoveDirection = Vector3.zero;
        DefaultGravityIntensity = 10.0f;
        CurrentGravity = Vector3.down * DefaultGravityIntensity;

        PlayerMoveSpeed = 20.0f;
        PlayerJumpSpeed = 2.50f;
        PlayerFactorReductionSpeedInAir = 0.5f;
    }


    //--------------------------------------------------------------------------//
    //--------------------------------------------------------------------------//
    public void Update()
    {
        // Handle the Jump input of the player 1
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
            MoveRight(Input.GetAxis("HorizontalKP1"));
        }
        else
        {
            // In air the player can move with a reduction of movement
            MoveRight(Input.GetAxis("HorizontalKP1") * PlayerFactorReductionSpeedInAir);
        }

        // Application of the gravity force passed by parameter
        ApplyGravity(CurrentGravity);

        // The function Move of the controller has to be the last function called
        PlayerController.Move(PlayerMoveDirection * PlayerMoveSpeed * Time.deltaTime);
    }

    //--------------------------------------------------------------------------//
    //--------------------------------------------------------------------------//

    /** Function useful to change locally the gravity*/
    public void ApplyGravity(Vector3 GravityDirection)
    {
        PlayerMoveDirection += GravityDirection * Time.deltaTime;
    }

    //--------------------------------------------------------------------------//
    //--------------------------------------------------------------------------//

    // The function used when player jump, modify the PlayerMoveDirection
    public void Jump()
    {
        PlayerMoveDirection.y = PlayerJumpSpeed;
    }

    //--------------------------------------------------------------------------//
    //--------------------------------------------------------------------------//

    // Same as the Jump() function, modify the PlayerMoveDirection
    public void MoveRight(float HorizontalValue)
    {
        PlayerMoveDirection.x = HorizontalValue;
    }

}
