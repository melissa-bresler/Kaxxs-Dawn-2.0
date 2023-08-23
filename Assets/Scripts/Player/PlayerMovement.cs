using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

//This requires these elements to be linked to this script, otherwise it won't run.
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour, IControllable, IDataPersistence
{
    private CharacterController _characterController;
    private float _speed = 1f;
    private Vector2 _playerMovementInput;

    private float _runSpeed = 2f;
    private bool run = false;
    public bool block = false;

    private Animator anim;
    private float rotationSpeed = 500f;

    private PlayerInput controls;
    private Transform mainCameraTransform;

    private HealthDisplay healthDisplay;

    public bool Enabled { get; set; } = true;


    void Awake()
    {
        _characterController = GetComponent<CharacterController>(); //TODO: What is the purpose of this?
        anim = GetComponent<Animator>(); //Links animator to character

        controls = new PlayerInput(); //Links controls to input from user i.e. which buttons get pressed (arrows keys/ASWD)
        mainCameraTransform = Camera.main.transform; //Used for finding the direction the camera is facing.

        healthDisplay = GetComponent<HealthDisplay>(); //TODO: What is the purpose of this?

    }

    private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    public void update()
    {
        MovePlayer();
        healthDisplay.update(); //TODO: Figure out what this does

    }

    void MovePlayer()
    {
        if (!Enabled) //By disabling this parameter, player movement can be disabled as the rest of this method will not run.
        {
            _characterController.SimpleMove(Vector3.zero);
            return;
        }

        Vector3 movement;

        if (block)
        {
            movement = Vector3.zero; //Player is unable to move while blocking.
            anim.SetBool("isBlocking", true); //Play blocking animation.
        }

        if (!block)
        {
            anim.SetBool("isBlocking", false); //Disable blocking animation.


            //This ensures that the player controls adjust according which way the camera is facing so that the controls always match what the user is able to see.
            Vector3 cameraForward = mainCameraTransform.forward;
            cameraForward.y = 0f;
            cameraForward.Normalize();

            Vector3 cameraRight = mainCameraTransform.right;
            cameraRight.y = 0f;
            cameraRight.Normalize();

            movement = (cameraForward * _playerMovementInput.y + cameraRight * _playerMovementInput.x) * _speed;

            _characterController.SimpleMove(movement * _speed); //Moves player is correct direcvtion with specified speed.

            //Starts walking animation and rotates player to direction of movement.
            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                anim.SetBool("isWalking", true);

                //These enabled/disable the running animation and adjust the speed.
                if (!run)
                {
                    anim.SetBool("isRunning", false);
                    _characterController.SimpleMove(movement * _speed);
                }

                if (run)
                {
                    anim.SetBool("isRunning", true);
                    _characterController.SimpleMove(movement * _runSpeed);
                }

            }

            //Stops walking and running animation when player stops moving
            if (movement == Vector3.zero)
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalking", false);
            }

        }

    }

    void OnMove(InputValue iv)
    {
        _playerMovementInput = iv.Get<Vector2>(); //Sets the value of the keys pressed to _playerMovementInput.
    }

    void OnRun() //This activates when the appropriate key is pressed and released.
    {
        run = !run;
    }

    void OnAttack()
    {
        anim.SetTrigger("isAttacking");
    }

    void OnJump()
    {

        if (!block)
        {
            anim.SetTrigger("isJumping");
        }
        //TODO: Maybe do the bellow by adding an extra methos with a coroutine delaying mvoement.
        //Character should stop moving when jumping
        //Set some sort of trigger within the code?

    }

    void OnBlock() //This activates when the appropriate key is pressed and released.
    {
        block = !block;
    }

    void OnSlide()
    {
        if (!block)
        {
            anim.SetTrigger("isSliding");
        }
    }

    void OnKick()
    {
        if (!block)
        {
            anim.SetTrigger("isKicking");
        }
    }

    public bool GetIsBlocking()
    {
        return block;
    }


    //TODO: Clean this up later
    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        Debug.Log("Loading player positon data: " + this.transform.position);
        ////this.transform.rotation = data.playerRotation;
        //this.transform.rotation = Quaternion.Euler(data.playerRotation.z, data.playerRotation.x, data.playerRotation.y);
    }

    public void SaveData(GameData data)
    {
        data.playerPosition = this.transform.position;
        Debug.Log("Saving player positon data: " + data.playerPosition);
        //data.playerRotation = this.transform.rotation.eulerAngles;

    }
}
