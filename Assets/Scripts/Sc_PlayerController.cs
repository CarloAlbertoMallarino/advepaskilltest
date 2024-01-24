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
    [SerializeField] private Transform cam;
    public CinemachineFreeLook camer;

    private CustomInput input;
    private Vector3 moveVector;
    private Vector3 movementDirection;
    private CharacterController controller;

    private void Awake()
    {
        input = new CustomInput();
        controller = GetComponent<CharacterController>();
        cam = Camera.main.transform;
        
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        movementDirection = RotatePlayer() * moveVector;
        controller.Move(movementDirection * forwardSpeed * Time.deltaTime);
    }

    private Quaternion RotatePlayer()
    {
        Quaternion rotation = Quaternion.Euler(0, camer.m_XAxis.Value, 0); //get the angle of the x axis of the cinemachine
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 10 * Time.deltaTime);

        return rotation;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }



    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector3>();
        //print(moveVector);
    }

    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector3.zero;
    }
}
