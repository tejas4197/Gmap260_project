using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public Camera mainCamera;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballInCameraPos = mainCamera.WorldToViewportPoint(gameObject.transform.position);

        //If ball is not in camera
        if (ballInCameraPos.x < 0 || ballInCameraPos.x > 1 || ballInCameraPos.y < 0 || ballInCameraPos.y > 1)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }
}
