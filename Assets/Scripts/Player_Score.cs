using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts;

public class Player_Score : MonoBehaviour
{
    private float timeLeft = 100f;
    public  int score = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public GameObject highScore;
    public static bool isOver = false;
    string sceneName;
    GameObject[] bubbles;
    private LevelsManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = new LevelsManager();

        Scene m_Scene = SceneManager.GetActiveScene(); // get a handle on the active scene
        sceneName = m_Scene.name; // get a handle on the active scene name
        highScore.gameObject.GetComponent<Text>().text = "High Score " + HighScore.getHighScore(sceneName); // load the highscore from the player prefs

        if (sceneName == "Bubble4")
        {
            timeLeft = 130f;
        }

        if (sceneName == "Bubble5")
        {
            timeLeft = 300f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        bubbles = GameObject.FindGameObjectsWithTag("Ball");

        if (bubbles.Length < 1)
        {
            CountScore();
            manager.ChangeLevel(Levels.Levels_Menu);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = "Time Left: " + (int)timeLeft;
        playerScoreUI.gameObject.GetComponent<Text>().text = "Lives: " + BubbleMove.lives;
        if (timeLeft < 0.1f) // if the time runs out
        {
            SceneManager.LoadScene("Level");// Reload SampleScene.

        }

        if (isOver == true)
        {
            Debug.Log((int)timeLeft);
            Debug.Log("----------------------------------------------------");
            CountScore();
            isOver = false;
        }

    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        
        if (trig.gameObject.name == "EndLevel")
        {
            CountScore();
            Debug.Log("End.");
        }
    }

    public void CountScore()
    {
        Scene m_Scene = SceneManager.GetActiveScene(); // get a handle on the active scene
        string sceneName = m_Scene.name; // get a handle on the active scenes name

       
        int score = 0;
        score = (int)(timeLeft * 10); // calculate the current score with this formula
        Debug.Log("Score ---> " + score);


        //HighScore.setHighScore(sceneName, 10); // override the high score with the current score
        int highScore = HighScore.getHighScore(sceneName);// get a handle on the high socre for the active scene
        if (score > highScore) // if the current score is higher than the highscore
        {
            if (highScore != 999)
            {
                HighScore.setHighScore(sceneName, score); // override the high score with the current score
            }
            
        }

        
    }

}
