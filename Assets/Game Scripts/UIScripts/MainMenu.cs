using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void StartCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void StartExit()
    {
        Application.Quit();

        // saat unity editor, stop playing the scene
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void StartMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
