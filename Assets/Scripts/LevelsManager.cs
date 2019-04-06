using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour // Class to control the changing of scenes.
{
    public void ChangeLevel(string level)
    {

        SceneManager.LoadScene(level); // Change scene.
    }

    public void QuitGame()
    {
        Application.Quit(); // Closes the application once this method is triggered.
    }

}
