using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    public Canvas winUI;
    //public Image winUI;
    //public bool isEnabled = false;

    // Use this for initialization
    void Start () {
        //winUI.text = "";
        Time.timeScale = 1f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        {
            winUI.GetComponent<Image>().enabled = true;
            //slow motion when player completes the level
            //winUI.text = "Level Complete!";
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
