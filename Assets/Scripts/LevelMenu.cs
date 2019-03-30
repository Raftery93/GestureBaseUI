using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class LevelMenu : MonoBehaviour
{

    private LevelsManager levelManager; // Get handle on LevelManager object.

    // Start is called before the first frame update
    void Start()
    {
        levelManager = new LevelsManager();// Create new instance of level manager.
    }

    // Different Options
    public void Level1()
    {
        SwitchScene(Levels.Level_1);
    }

    // Different Options
    public void Level2()
    {
        SwitchScene(Levels.Level_2);
    }

    // Different Options
    public void Level3()
    {
        SwitchScene(Levels.Level_3);
    }

    // Different Options
    public void Level4()
    {
        SwitchScene(Levels.Level_4);
    }

    // Different Options
    public void Level5()
    {
        SwitchScene(Levels.Level_5);
    }

    public void redirect()
    {
        SwitchScene(Levels.Main_Menu);
    }

    void SwitchScene(string sceneName) // Delegate the navigation of levels to its own method.
    {
        levelManager.ChangeLevel(sceneName);// Change scene when this method is triggered.
    }
}
