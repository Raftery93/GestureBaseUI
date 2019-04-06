using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour // Class to access the High score in local storage.
{


    public static int getHighScore(string level) // Use a static method so we can access it without needing an instance.
    {
        return PlayerPrefs.GetInt(level); // Return the highscore for the level that was passed in.
    }

    public static void setHighScore(string level, int score) // Use a static method so we can access it without needing an instance.
    {
        PlayerPrefs.SetInt(level, score); // Set the high score for the level that was passed in, using the score that was passed in.
    }

    
}
