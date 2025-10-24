using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame() {
        // Load scene with build index 1
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}