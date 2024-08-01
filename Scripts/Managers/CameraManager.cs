using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 5.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float speed_modifier = 0;

        // Handle mouse input
        if (Input.GetMouseButton(1))
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * sensitivity;
            rotationY = Mathf.Clamp(rotationY, -90, 90);
        }
        else{
            Cursor.lockState = CursorLockMode.None;
        }

        

        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);

        // Handle keyboard input
        float moveForward = Input.GetKey(KeyCode.W) ? 1.0f : (Input.GetKey(KeyCode.S) ? -1.0f : 0);
        float moveRight = Input.GetKey(KeyCode.A) ? -1.0f : (Input.GetKey(KeyCode.D) ? 1.0f : 0);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed_modifier = 5.0f;
        }
        Vector3 movement = new Vector3(moveRight, 0, moveForward) * speed * Time.deltaTime * speed_modifier;
        movement = transform.rotation * movement;

        transform.position += movement;

    }
}
