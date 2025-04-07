using UnityEngine;

public class MultiTouchLookController : MonoBehaviour
{
    public float sensitivity = 0.1f; // Sensitivity for look movement
    public Transform playerBody; // Reference to the player's body

    private float xRotation = 0f;

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Iterate through all active touches
            foreach (Touch touch in Input.touches)
            {
                // Only process input if the touch started on the right side of the screen
                if (touch.position.x > Screen.width / 2)
                {
                    if (touch.phase == TouchPhase.Moved)
                    {
                        // Get touch delta movement
                        Vector2 touchDelta = touch.deltaPosition * sensitivity;

                        // Adjust vertical rotation (clamp to prevent flipping)
                        xRotation -= touchDelta.y;
                        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                        // Apply rotation
                        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Vertical rotation for camera
                        playerBody.Rotate(Vector3.up * touchDelta.x); // Horizontal rotation for player body
                    }
                }
            }
        }
    }
}
