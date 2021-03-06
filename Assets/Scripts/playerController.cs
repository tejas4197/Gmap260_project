﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public Camera mainCamera;
    public float trampolineForce;
    public GameObject conveyor;
    public GameObject trampoline;

    public Image gameoverUI;

    // Use this for initialization
    void Start()
    {
        //gameoverUI.text = "";
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballInCameraPos = mainCamera.WorldToViewportPoint(gameObject.transform.position);

        //If ball is not in camera
        if (ballInCameraPos.x < 0 || ballInCameraPos.x > 1 || ballInCameraPos.y < 0 || ballInCameraPos.y > 1)
        {
            gameoverUI.enabled = true;
            //gameoverUI.text = "Game Over";
            Invoke("LoadScene", 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == string.Format("{0}(Clone)", trampoline.name))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(collision.contacts[0].normal * trampolineForce);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == string.Format("{0}(Clone)", conveyor.name))
        {
            var rotation = collision.gameObject.transform.eulerAngles.z;
            var dir = rotation == 90 ? 1 : -1;

            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(dir * 10, 3));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == string.Format("{0}(Clone)", conveyor.name))
            gameObject.GetComponent<Rigidbody2D>().velocity = (new Vector2(0, 3));
    }

    void LoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
