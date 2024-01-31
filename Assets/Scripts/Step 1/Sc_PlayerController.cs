using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Sc_PlayerController : MonoBehaviour
{
    private CinemachineFreeLook camRef;
    private float camXMaxSpeed;
    private float camYMaxSpeed;
    private CustomInput input;
    private CharacterController controller;

    private Animator animator;

    private Vector2 currentMovement;
    private bool runPressed;
    private bool lockPressed;
    private void Awake()
    {
        input = new CustomInput();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
        InputSubscription();
    }

    private void Update()
    {
        HandleMovement();
        RotatePlayer();
    }

    private void OnEnable()
    {
        input.Player.Enable();
    }

    private void OnDisable()
    {
        input.Player.Disable();
    }

    private void InputSubscription()
    {
        input.Player.Movement.performed += ctx => currentMovement = ctx.ReadValue<Vector2>();
        input.Player.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
        input.Player.LockScreen.performed += ctx => ToggleCameraLock();
    }

    #region Movement
    private void HandleMovement()
    {
        animator.SetFloat("Y", currentMovement.y);
        animator.SetFloat("X", currentMovement.x);
        animator.SetBool("isRunning", runPressed);
        print(currentMovement);
    }

    private void OnAnimatorMove()
    {
        Vector3 velocity = animator.deltaPosition;
        velocity.y = Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity);
    }

    private void RotatePlayer()
    {
        if(camRef != null)
        {
            Quaternion rotation = Quaternion.Euler(0, camRef.m_XAxis.Value, 0); //get the angle of the x axis of the cinemachine
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 20 * Time.deltaTime);
        }
    }

    #endregion

    #region Camera
    public void SetCamera(CinemachineFreeLook cam)
    {
        camRef = cam;
        camXMaxSpeed = camRef.m_XAxis.m_MaxSpeed;
        camYMaxSpeed = camRef.m_YAxis.m_MaxSpeed;
    }

    private void ToggleCameraLock()
    {
        lockPressed = !lockPressed;

        if(lockPressed)
        {
            camRef.m_XAxis.m_MaxSpeed = 0;
            camRef.m_YAxis.m_MaxSpeed = 0;
        }
        else
        {
            camRef.m_XAxis.m_MaxSpeed = camXMaxSpeed;
            camRef.m_YAxis.m_MaxSpeed = camYMaxSpeed;
        } 
    }

    #endregion

}
