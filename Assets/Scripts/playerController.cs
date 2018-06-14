using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject conveyor;

    public Text winUI;
    public Text gameoverUI;

    // Use this for initialization
    void Start()
    {
        winUI.text = "";
        gameoverUI.text = "";
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ballInCameraPos = mainCamera.WorldToViewportPoint(gameObject.transform.position);

        //If ball is not in camera
        if (ballInCameraPos.x < 0 || ballInCameraPos.x > 1 || ballInCameraPos.y < 0 || ballInCameraPos.y > 1)
        {
            gameoverUI.text = "Game Over";
            Invoke("LoadScene", 2f);
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

    private void OnCollisionEnter(Collision2D col)
    {
        {
            //slow motion when player completes the level
            winUI.text = "Level Complete!";
            Time.timeScale = .25f;

            //reload the level
            Invoke("LoadScene", 1f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
