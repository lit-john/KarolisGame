using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInPlace : MonoBehaviour
{
    private Camera mainCamera;

    // Screen position offsets from the center of the screen
    public Vector2 screenOffset = Vector2.zero;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        // Calculate the position of the object in world space
        Vector3 worldPosition = transform.position;

        // Convert the world position to screen space
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

        // Get the center of the screen
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);

        // Apply screen offset
        screenPosition.x = screenCenter.x + screenOffset.x;
        screenPosition.y = screenCenter.y + screenOffset.y;

        // Convert the adjusted screen position back to world space
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(screenPosition);

        // Keep the z-position unchanged to prevent the object from moving closer or farther from the camera
        newPosition.z = transform.position.z;

        // Update the object's position to the new position
        transform.position = newPosition;
    }
}
