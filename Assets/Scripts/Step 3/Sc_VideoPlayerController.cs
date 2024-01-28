using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Sc_VideoPlayerController : MonoBehaviour
{
    private VideoPlayer player;
    [SerializeField] private string URL;

    private void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.url = URL;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            player.Stop();
        if (Input.GetKeyDown(KeyCode.Alpha3))
            player.Play();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            player.Pause();
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
