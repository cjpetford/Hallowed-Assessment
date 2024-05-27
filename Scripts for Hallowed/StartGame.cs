using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenuManager : MonoBehaviour
{
    public GameObject controlsPanel;
    public Animator transitionAnimator;

    public void StartGame()
    {
        StartCoroutine(LoadGameScene());
    }

    private IEnumerator LoadGameScene()
    {
        // Optional: Play transition animation here if needed

        // Yield control back to Unity for one frame
        yield return null;

        // Load the Game Scene
        SceneManager.LoadScene("GameScene");
    }

    public void ShowControls()
    {
        controlsPanel.SetActive(true);
    }

    public void HideControls()
    {
        controlsPanel.SetActive(false);
    }
}
