using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoTransition : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        Time.timeScale = 1; // Ensure the game is not paused
        videoPlayer = GetComponent<VideoPlayer>();

        // Register callback for when the video finishes playing
        videoPlayer.loopPointReached += OnVideoFinished;

        // Start playing the video
        videoPlayer.Play();
    }


    void OnVideoFinished(VideoPlayer vp)
    {
        // Load the main menu scene when the video finishes
        SceneManager.LoadScene("MainMenu");
    }
}
