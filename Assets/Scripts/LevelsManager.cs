﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
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
