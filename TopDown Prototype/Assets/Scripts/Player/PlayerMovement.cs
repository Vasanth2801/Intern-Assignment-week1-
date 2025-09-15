using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private  float speed = 5f;                                      // speed of the player                                                        
    [SerializeField] private float sprintBoost = 12f;                              // sprint boost speed of the player

    [Header("References")]
    PlayerInputHandler controls;                                  //Refrence to the TopDownController input action
    Rigidbody2D rb;                                                                //Rigidbody component
    private Vector2 movement;                                                   // movement vector

    [Header("Sprinting")]
    bool isSprinting;                                             //Boolean to check if the player is sprinting

    [Header("Dashing")]

    bool isDashing;                                              //Boolean to check if the player is dashing
    float dashTime;                                              //Time for which the player will dash
    float dashSpeed = 20f;                                       //Speed of the dash
    float dashCooldown = 1f;                                     //Cooldown time for the dash
    float dashDuration = 0.2f;                                    //Duration of the dash
    float lastDash;                                  //Time when the last dash was performed
    bool dashPressed;                                          //Boolean to check if the dash button is pressed

    [Header("Shooting")]

    bool isShooting;                                            //Boolean to check if the player is shooting

    //Calls the function before the game starts
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();                          //Getting the reference to the Rigidbody component

        controls = new PlayerInputHandler();                       //Creating a new instance of TopDownController

        MovementCalling();                                         //Calling the Movementcalling function

        CheckSprint();                                             //Calling the CheckSprint function

        CheckDash();                                               //Calling the CheckDash function
    }

    //making the movement enabled when the button is enabled
    void MovementCalling()
    {
        controls.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();               //Reading the movement input
        controls.Player.Move.canceled += ctx => movement = Vector2.zero;                            //Resetting the movement input
    }

    void CheckSprint()
    {
        controls.Player.Sprint.performed += ctx => isSprinting = true;                          //Increasing the speed when sprint button is pressed
        controls.Player.Sprint.canceled += ctx => isSprinting = false;                             //Resetting the speed when sprint button is released
    }

    void CheckDash()
    {
        controls.Player.Dash.performed += ctx => dashPressed = true;                             //Setting the dashPressed to true when dash button is pressed
        controls.Player.Dash.canceled += ctx => dashPressed = false;                            //Setting the dashPressed to false when dash button is released
    }

    //Enabling the input system when the button is enabled
    private void OnEnable()
    {
        controls.Player.Enable();                                                                        //Enabling the input System
    }

    //Disabling the input system when the button is disabled
    private void OnDisable()
    {
        controls.Player.Disable();                                                                     //Disabling the input System
    }

    //Called at a fixed interval and better for physics calculations
    private void FixedUpdate()
    {
        if (isDashing)
        {
            HandleDash();                                                                             //Function to handle the dash of the player
        }
        else
        {
            HandleMovement();                                                                             //Function to handle the movemnt of the player 
        }

        if(dashPressed && Time.time >= lastDash + dashCooldown)                                                                          //Checking if the dash button is pressed and dashTime is true
        {
            StartDash();
        }

    }

    //Function to handle the movement of the player
    void HandleMovement()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);                            //Moving the player based on the input


        if(isSprinting)
        {
            speed = sprintBoost;                                                                 //Increasing the speed when sprinting
        }
        else
        {
            speed = 7f;                                                                          //Resetting the speed when not sprinting
        }
    }


    void StartDash()
    {
        isDashing = true;                                            //Setting isDashing to true
        dashTime = dashDuration;                                     //Setting dashTime to dashDuration
        lastDash = Time.time;                                       //Setting lastDash to current time

        rb.linearVelocity = movement.normalized * dashSpeed;            //Setting the velocity of the player to dashSpeed in the direction of movement
    }

    void HandleDash()
    {
        if(dashTime > 0)
        {
            dashTime -= Time.fixedDeltaTime;                          //Decreasing the dashTime
        }
        else
        {
            isDashing = false;                                        //Setting isDashing to false
            rb.linearVelocity = Vector2.zero;                               //Resetting the velocity of the player
        }
    }

}
