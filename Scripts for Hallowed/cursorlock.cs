using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private bool isCursorLocked = true;

    private void Start()
    {
        LockCursor();
    }

    private void Update()
    {
        // Toggle cursor lock when the player presses the "P" key
        if (Input.GetKeyDown(KeyCode.P))
        {
            ToggleCursorLock();
        }

        // Unlock cursor when the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
            isCursorLocked = false; // Ensure cursor is unlocked when Escape is pressed
        }
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Release cursor lock
        Cursor.visible = true; // Show the cursor
    }

    private void ToggleCursorLock()
    {
        isCursorLocked = !isCursorLocked;
        if (isCursorLocked)
            LockCursor();
        else
            UnlockCursor();
    }
}
