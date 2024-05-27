using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // Ensure the video player is set
        if (videoPlayer != null)
        {
            // Set the video to loop
            videoPlayer.isLooping = true;

            // Start playing the video
            videoPlayer.Play();
        }
    }
}
