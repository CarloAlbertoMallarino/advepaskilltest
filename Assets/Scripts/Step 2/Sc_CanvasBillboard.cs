using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Sc_CanvasBillboard : MonoBehaviour
{
    public Transform cinemachineCameraTransform;

    private void LateUpdate()
    {

        //transform.LookAt(transform.position + Camera.main.transform.forward, Camera.main.transform.up);
        //transform.LookAt(transform.position + cam.transform.forward, cam.transform.up);
        //print(cam.gameObject.transform.position);
        transform.LookAt(transform.position + cinemachineCameraTransform.forward, cinemachineCameraTransform.up);
    }
}

