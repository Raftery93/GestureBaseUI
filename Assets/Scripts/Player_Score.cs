using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts;

public class Player_Score : MonoBehaviour // Class to control what the players score is.
{
    private float timeLeft = 100f; // Initialize the default amount of time each level should have.
    public  int score = 0; // Initialize the players score to 0.
    public GameObject timeLeftUI; // Get a handle of the timeLeftUI.
    public GameObject playerScoreUI; // Get a handle on the playerScoreUI(Now used to display the players lives).
    public GameObject highScore; // Get a handle on the highScore UI.
    public static bool isOver = false; // Boolean to trigger the CountScore() method.
    string sceneName; // Get a handle on the current scenes name.
    GameObject[] bubbles; // Get a reference to the amount of bubbles left in the scene.
    private LevelsManager manager;  // Get a handle on the levels manager.

    // Start is called before the first frame update
    void Start()
    {
        manager = new LevelsManager(); 

        Scene m_Scene = SceneManager.GetActiveScene(); // Get a handle on the active scene.
        sceneName = m_Scene.name; // Get a handle on the active scene name.
        highScore.gameObject.GetComponent<Text>().text = "High Score " + HighScore.getHighScore(sceneName); // Load the highscore from the player prefs.

        if (sceneName == Levels.Level_4) // Reset the time left if it is level 4.
        {
            timeLeft = 130f;
        }

        if (sceneName == Levels.Level_5) // Reset the time left if it is level 5.
        {
            timeLeft = 300f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        bubbles = GameObject.FindGameObjectsWithTag(Tags.Ball); // Find all of the bubbles in the scene.

        if (bubbles.Length < 1) // If there are no bubbles left, count the score.
        {
            CountScore();
            manager.ChangeLevel(Levels.Levels_Menu); // Load the levels menu.
        }

        /*
        Update the scoreboard UI.
         */
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = "Time Left: " + (int)timeLeft;
        playerScoreUI.gameObject.GetComponent<Text>().text = "Lives: " + BubbleMove.lives;
        if (timeLeft < 0.1f) // If the time runs out.
        {
            SceneManager.LoadScene(Levels.Levels_Menu);// Reload the levels menu.

        }

        if (isOver == true)
        {
            Debug.Log((int)timeLeft);
            CountScore();
            isOver = false;
        }

    }

    /*
    Method no longer significant because it was only used for the old game to trigger when the player completed a level.
     */
    void OnTriggerEnter2D(Collider2D trig)
    {
        
        if (trig.gameObject.name == "EndLevel")
        {
            CountScore();
            Debug.Log("End.");
        }
    }

    public void CountScore() // Count the players score.
    {
        Scene m_Scene = SceneManager.GetActiveScene(); // Get a handle on the active scene.
        string sceneName = m_Scene.name; // Get a handle on the active scenes name.

       
        int score = 0;
        score = (int)(timeLeft * 10); // Calculate the current score with this formula.
        Debug.Log("Score ---> " + score);

        int highScore = HighScore.getHighScore(sceneName);// Get a handle on the high socre for the active scene.
        if (score > highScore) // If the current score is higher than the highscore.
        {
            if (highScore != 999) // Sometimes the high score bugs out to 999.
            {
                HighScore.setHighScore(sceneName, score); // Override the high score with the current score.
            }
            
        }

        
    }

}
