using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Sc_SceneManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerStart;

    [Header("Camera")]
    [SerializeField] private CinemachineFreeLook cinemachineCamera;
    private void Start()
    {
        GameObject player = Instantiate(playerPrefab, playerStart.position, playerStart.rotation);
        player.GetComponent<Sc_PlayerController>().SetCamera(cinemachineCamera);
        cinemachineCamera.m_Follow = player.transform;
        cinemachineCamera.m_LookAt = player.transform;
    } 
    
    public void LoadSceneAdditive(string sceneName)
    {
        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        else
            SceneManager.UnloadSceneAsync(sceneName);

              
    }
}
