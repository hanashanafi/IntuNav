using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFix : MonoBehaviour
{
    public bool isPrimaryCamera = true; // Flag to determine if this is the primary camera
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 2.0f;
    public float verticalMoveSpeed = 3.0f;
    public float scrollSpeed = 2.0f;

    private void Update()
    {
        if (!isPrimaryCamera)
            return; // Exit the function if this is not the primary camera

        // Get mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Check for right mouse button
        if (Input.GetMouseButton(1))
        {
            // Move the camera up and down when right-clicking and moving the mouse along the Y-axis
            transform.Translate(Vector3.up * mouseY * verticalMoveSpeed * Time.deltaTime);

            // Move the camera left and right when right-clicking and moving the mouse along the X-axis
            transform.Translate(Vector3.right * mouseX * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Rotate the camera horizontally when not right-clicking
            transform.Rotate(Vector3.up * mouseX * rotationSpeed);

            // Move the camera forwards/backwards when not right-clicking
            transform.Translate(Vector3.forward * mouseY * moveSpeed * Time.deltaTime);
        }
        /*
        // Rotate the camera upwards when scrolling the mouse wheel forward
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Rotate(Vector3.left * scrollSpeed);
        }
        // Rotate the camera downwards when scrolling the mouse wheel backward
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Rotate(Vector3.right * scrollSpeed);
        }
        */

        // Hide the cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

}

