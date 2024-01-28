using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Sc_CanvasBillboard : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineCamera;

    void Start()
    {
        cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();

        if (cinemachineCamera == null)
        {
            Debug.LogError("Cinemachine virtual camera not found in the scene!");
        }
    }

    void LateUpdate()
    {
        if (cinemachineCamera != null)
        {
            transform.LookAt(cinemachineCamera.transform, Vector3.up);
        }
    }
}

