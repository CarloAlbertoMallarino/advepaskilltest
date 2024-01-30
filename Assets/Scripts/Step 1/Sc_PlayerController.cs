using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Sc_PlayerController : MonoBehaviour
{
    private CinemachineFreeLook camRef;

    private CustomInput input;
    private CharacterController controller;

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

    private void Update()
    {
        HandleMovement();
        RotatePlayer();
    }

    private void HandleMovement()
    {
        animator.SetFloat("Y", currentMovement.y);
        animator.SetFloat("X", currentMovement.x);
        animator.SetBool("isRunning", runPressed);
    }

    private void RotatePlayer()
    {
        if(camRef != null)
        {
            Quaternion rotation = Quaternion.Euler(0, camRef.m_XAxis.Value, 0); //get the angle of the x axis of the cinemachine
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 20 * Time.deltaTime);
        }

    }

    private void OnEnable()
    {
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }

    public void SetCamera(CinemachineFreeLook cam)
    {
        camRef = cam;
    }
   
}
