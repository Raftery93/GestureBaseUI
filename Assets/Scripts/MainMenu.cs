﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class MainMenu : MonoBehaviour
{

    private LevelsManager levelManager; // Get handle on LevelManager object.

    // Start is called before the first frame update
    void Start()
    {
        levelManager = new LevelsManager();// Create new instance of level manager.
    }

    public void PlayGame()
    {
       
        levelManager.ChangeLevel(Levels.Level_1);// Change level when this method is triggered.
    }

    public void Quit()
    {
        levelManager.QuitGame();// When the user clicks "QUIT".
    }
}
