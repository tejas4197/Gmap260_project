using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Creator : MonoBehaviour
{

    public GameObject trampoline;
    public Camera mainCamera;
    Vector3 mouseClickPos;
    Vector3 mouseReleasePos;
    Ray mouseRay;
    RaycastHit hit;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // If left mouse button was clicked this frame
        {
            mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out hit))
                mouseClickPos = new Vector3(hit.point.x, hit.point.y, 0); // Position according to camera where the mouse click occurred
        }
        else if (Input.GetMouseButtonUp(0)) // If right mouse button was released this frame
        {
            float angle;

            mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out hit))
            {
                // Get identity quaternion so we can set the angle using Quaternion.eulerAngles
                Quaternion objectRotation = Quaternion.identity;

                // Position according to camera where the mouse was released
                mouseReleasePos = new Vector3(hit.point.x, hit.point.y, 0);

                // Use inverse tangent to figure out angle between mouse click and release
                angle = Mathf.Atan((mouseReleasePos.y - mouseClickPos.y) / (mouseReleasePos.x - mouseClickPos.x)) * 180 / Mathf.PI;

                // Quaternion representation of desired rotation of the object to be instantiated
                // Ternary operator checks for NaN in case mouse click occurred in same location as mouse release (which would cause arctan(0/0))
                objectRotation.eulerAngles = new Vector3(0, 0, (float.IsNaN(angle) ? 0 : angle - 90));

                // Instantiate object at desired location with desired rotation
                Instantiate(trampoline, mouseClickPos, objectRotation);
            }
        }
    }
}
