using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object hit has the tag "unit"
                if (hit.collider.CompareTag("Unit"))
                {
                    // Print the name of the object
                    Debug.Log("Clicked on unit: " + hit.collider.gameObject.name);
                    Debug.Log("Units In Range: " + hit.collider.gameObject.GetComponent<Unit>().UnitsInAwareness());
                }
            }
        }
    }
}
