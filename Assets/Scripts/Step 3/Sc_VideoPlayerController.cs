using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Sc_VideoPlayerController : MonoBehaviour
{
    private VideoPlayer player;
    [SerializeField] private string URL;
    [SerializeField] private GameObject uiControls;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.url = URL;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
            uiControls.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            uiControls.SetActive(false);
    }
    public void PlayClip()
    {
        player.Play();
    }
    public void PauseClip()
    {
        player.Pause();
    }
    public void StopClip()
    {
        player.Stop();
    }


}
