using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

//This requires these elements to be linked to this script, otherwise it won't run.
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _characterController;
    private float _speed = 1f;
    private Vector2 _playerMovementInput;

    private float _runSpeed = 2f;
    private bool run = false;
    private bool block = false;

    private Animator anim;
    private float rotationSpeed = 500f; //720


    //Do I have to enable/disable something?


    // Start is called before the first frame update
    void Awake() //Changed from start
    {
        Debug.Log("Player Created.");
        _characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
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
            movement = new Vector3(_playerMovementInput.x, 0.0f, _playerMovementInput.y);
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
}
