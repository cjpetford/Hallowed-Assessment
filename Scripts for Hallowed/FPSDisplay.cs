using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
    // Field to store the desired target frame rate
    public int targetFPS = 144;

    // Time scale adjustment factor
    private float timeScaleFactor = 1.0f;

    float deltaTime = 0.0f;

    void Start()
    {
        // Set the target frame rate
        Application.targetFrameRate = targetFPS;
    }

    void Update()
    {
        // Calculate time scale adjustment factor based on current frame rate
        timeScaleFactor = Mathf.Min(targetFPS / (float)Application.targetFrameRate, 1.0f);

        // Apply time scale adjustment
        Time.timeScale = timeScaleFactor;

        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 2 / 100;
        style.normal.textColor = new Color(1, 1, 1, 1.0f);
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, style);
    }
}
