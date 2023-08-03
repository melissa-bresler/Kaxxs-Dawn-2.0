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
    private float rotationSpeed = 500f; //720

    private PlayerInput controls;
    private Transform mainCameraTransform;

    private HealthDisplay healthDisplay;


    //Do I have to enable/disable something?


    // Start is called before the first frame update
    void Awake() //Changed from start
    {
        //Debug.Log("Player Created.");
        _characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        controls = new PlayerInput();
        mainCameraTransform = Camera.main.transform;

        healthDisplay = GetComponent<HealthDisplay>();

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
        healthDisplay.update();

    }

    void MovePlayer()
    {
        Vector3 movement;

        if (block)
        {
            movement = Vector3.zero;
            anim.SetBool("isBlocking", true);
        }

        if (!block)
        {
            anim.SetBool("isBlocking", false);



            Vector3 cameraForward = mainCameraTransform.forward;
            cameraForward.y = 0f;
            cameraForward.Normalize();

            Vector3 cameraRight = mainCameraTransform.right;
            cameraRight.y = 0f;
            cameraRight.Normalize();

            movement = (cameraForward * _playerMovementInput.y + cameraRight * _playerMovementInput.x) * _speed;


            //Debug.Log("Y input: " + movementInput.y + ". X input: " + movementInput.x + "."); //Inputs are being received
            //Debug.Log("Movement: " + movement);






            //movement = new Vector3(_playerMovementInput.x, 0.0f, _playerMovementInput.y);
            _characterController.SimpleMove(movement * _speed);

            //Starts walking animation and rotates player to direction of movement.
            if (movement != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);

                anim.SetBool("isWalking", true);

                if (!run)
                {
                    //Debug.Log("Character is WALKING.");
                    anim.SetBool("isRunning", false);
                    _characterController.SimpleMove(movement * _speed);
                }

                if (run)
                {
                    //Debug.Log("Character is RUNNING.");
                    anim.SetBool("isRunning", true);
                    _characterController.SimpleMove(movement * _runSpeed);
                }

                //Debug.Log("Run= " + run);

            }

            //Stops walking animation
            if (movement == Vector3.zero)
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isWalking", false);
            }

        }




    }

    void OnMove(InputValue iv)
    {
        //Debug.Log("Movement pressed.");
        _playerMovementInput = iv.Get<Vector2>();
    }

    void OnRun()
    {
        //Debug.Log("Character is RUNNING.");
        run = !run;
    }

    void OnAttack()
    {
        //Debug.Log("Character is ATTACKING.");
        anim.SetTrigger("isAttacking");
        //anim.ResetTrigger("isAttacking");
    }

    void OnJump()
    {

        if (!block)
        {
            //_characterController.SimpleMove(Vector3.zero * 0); //This doesn't work
            anim.SetTrigger("isJumping");
        }
        //Character should stop moving when jumping
        //Set some sort of trigger within the code?

    }

    void OnBlock()
    {
        block = !block;
        //Debug.Log("Block status: " + block);
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
        //Debug.Log("Block status: " + block);
        return block;
    }

    public void LoadData(GameData data)
    {
        this.transform.position = data.playerPosition;
        //this.transform.rotation = data.playerRotation;
        this.transform.rotation = Quaternion.Euler(data.playerRotation.z, data.playerRotation.x, data.playerRotation.y);
    }

    public void SaveData(ref GameData data)
    {
        data.playerPosition = this.transform.position;
        data.playerRotation = this.transform.rotation.eulerAngles;

    }
}
