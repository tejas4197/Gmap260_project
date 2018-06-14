using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    // Gets next scene when start is pressed
	public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Quits the game when exit is pressed
    public void QuitGame()
    {
        Debug.Log("The Game Has Quit");
        Application.Quit();
    }
}
