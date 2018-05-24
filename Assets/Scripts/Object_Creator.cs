using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Creator : MonoBehaviour
{

    public GameObject trampoline;
    public GameObject conveyor;
    public GameObject wall;
    public Camera mainCamera;
    GameObject objectToPlace;
    Vector3 mouseClickPos;
    Vector3 mouseReleasePos;
    Ray mouseRay;
    RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        objectToPlace = trampoline;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            objectToPlace = trampoline;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            objectToPlace = conveyor;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            objectToPlace = wall;

        if (Input.GetMouseButtonDown(0)) // If left mouse button was clicked this frame
        {
            mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mouseRay, out hit))
                mouseClickPos = new Vector3(hit.point.x, hit.point.y, 0); // Position according to camera where the mouse click occurred
        }
        else if (Input.GetMouseButtonUp(0)) // If right mouse button was released this frame
        {
            PlaceObject(objectToPlace);
        }
    }

    private void PlaceObject(GameObject objectToPlace)
    {
        if (objectToPlace.Equals(trampoline) || objectToPlace.Equals(wall))
        {
            PlaceObjectWithRotation(objectToPlace);
        }
        else if (objectToPlace.Equals(conveyor))
        {
            PlaceObjectWithLimitedRotation(objectToPlace);
        }
    }

    private void PlaceObjectWithLimitedRotation(GameObject @object)
    {
        float angle;

        mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out hit))
        {
            // Get identity quaternion so we can set the angle using Quaternion.eulerAngles
            Quaternion objectRotation = Quaternion.identity;

            // Position according to camera where the mouse was released
            mouseReleasePos = new Vector3(hit.point.x, hit.point.y, 0);

            // Get change in X
            float deltaX = mouseReleasePos.x - mouseClickPos.x;

            // Fix orientation
            angle = deltaX > 0 ? 0 : 180;

            // Quaternion representation of desired rotation of the object to be instantiated
            objectRotation.eulerAngles = new Vector3(0, angle, 0);

            // Instantiate object at desired location with desired rotation
            Instantiate(@object, mouseClickPos, objectRotation);
        }
    }

    private void PlaceObjectWithRotation(GameObject @object)
    {
        float angle;

        mouseRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(mouseRay, out hit))
        {
            // Get identity quaternion so we can set the angle using Quaternion.eulerAngles
            Quaternion objectRotation = Quaternion.identity;

            // Position according to camera where the mouse was released
            mouseReleasePos = new Vector3(hit.point.x, hit.point.y, 0);

            // Get changes in positions for next calculation
            float deltaY = mouseReleasePos.y - mouseClickPos.y;
            float deltaX = mouseReleasePos.x - mouseClickPos.x;

            // Use inverse tangent to figure out angle between mouse click and release
            angle = Mathf.Atan(deltaY / deltaX) * 180 / Mathf.PI;

            // Check for arctan(0/0)
            angle = float.IsNaN(angle) ? 0 : angle;

            // Fix orientation
            angle = deltaX > 0 ? angle - 90 : angle + 90;

            // Quaternion representation of desired rotation of the object to be instantiated
            objectRotation.eulerAngles = new Vector3(0, 0, angle);

            // Instantiate object at desired location with desired rotation
            Instantiate(@object, mouseClickPos, objectRotation);
        }
    }
}
