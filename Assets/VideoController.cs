using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer; // El VideoPlayer

    void Start()
    {
        // Configura el VideoPlayer
        videoPlayer.playOnAwake = false;
        videoPlayer.loopPointReached += EndReached;
        
        // Reproduce el video cada vez que se inicia el Canvas
        PlayVideo();
    }

    void PlayVideo()
    {
        // Reproduce el video
        videoPlayer.Play();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        // Cuando el video termina, lo reproduce de nuevo
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        PlayVideo();
    }
}
