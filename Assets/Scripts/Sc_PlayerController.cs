using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Sc_PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float backwardSpeed;
    [SerializeField] private float lateralSpeed;
    [SerializeField] private CinemachineFreeLook camRef;

    private CustomInput input;
    private Vector3 moveVector;
    private Vector3 movementDirection;
    private CharacterController controller;

    //new
    private int isWalkingHash;
    private int isRunningHash;

    private Animator animator;

    private Vector2 currentMovement;
    private bool movementPressed;
    private bool runPressed;
    private void Awake()
    {
        input = new CustomInput();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        input.Player.Movement.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movementPressed = currentMovement.x != 0 || currentMovement.y != 0;
        };
        input.Player.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
    }

    private void Start()
    {
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    private void Update()
    {
        HandleMovement();
        //HandleRotation();
        RotatePlayer();
    }

    private void HandleMovement()
    {
        //bool isRunning = animator.GetBool(isRunningHash);
        //bool isWalking = animator.GetBool(isWalkingHash);

        print(currentMovement);

        //if (movementPressed && !isWalking)



        //if (!movementPressed && isWalking)
        //    animator.SetBool(isWalkingHash, false);

        //if ((movementPressed && runPressed) && !isRunning)
        //    animator.SetBool(isRunningHash, true);

        //if ((!movementPressed || !runPressed) && isRunning)
        //    animator.SetBool(isRunningHash, false);

        animator.SetFloat("Y", currentMovement.y);
        animator.SetFloat("X", currentMovement.x);
        animator.SetBool("isRunning", runPressed);

    }

    private void HandleRotation()
    {
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = new Vector3(currentMovement.x, 0, currentMovement.y);
        Vector3 positionToLookAt = currentPosition + newPosition;

        transform.LookAt(positionToLookAt);
    }

    private void RotatePlayer()
    {
        Quaternion rotation = Quaternion.Euler(0, camRef.m_XAxis.Value, 0); //get the angle of the x axis of the cinemachine
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 20 * Time.deltaTime);
    }


    private void OnEnable()
    {
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }
    //private void OnEnable()
    //{
    //    input.Enable();
    //    input.Player.Movement.performed += OnMovementPerformed;
    //    input.Player.Movement.canceled += OnMovementCancelled;
    //}

    //private void Update()
    //{
    //    MovePlayer();
    //}

    //private void OnAnimatorMove()
    //{

    //}
    //private void MovePlayer()
    //{
    //    movementDirection = RotatePlayer() * moveVector;

    //    //controller.Move(movementDirection * forwardSpeed * Time.deltaTime);
    //    controller.Move(movementDirection * forwardSpeed * Time.deltaTime);
    //}

    //private Quaternion RotatePlayer()
    //{
    //    Quaternion rotation = Quaternion.Euler(0, camRef.m_XAxis.Value, 0); //get the angle of the x axis of the cinemachine
    //    transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 20 * Time.deltaTime);

    //    return rotation;
    //}

    //private void OnDisable()
    //{
    //    input.Disable();
    //    input.Player.Movement.performed -= OnMovementPerformed;
    //    input.Player.Movement.canceled -= OnMovementCancelled;
    //}



    //private void OnMovementPerformed(InputAction.CallbackContext value)
    //{
    //    moveVector = value.ReadValue<Vector3>() + animator.deltaPosition;
    //    //print(moveVector);
    //}

    //private void OnMovementCancelled(InputAction.CallbackContext value)
    //{
    //    moveVector = Vector3.zero;
    //}
}
