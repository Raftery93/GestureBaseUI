using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour
{
    private float timeLeft = 120f;
    public int score = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public GameObject highScore;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = "Time Left: " + (int)timeLeft;
        playerScoreUI.gameObject.GetComponent<Text>().text = "Score: " + score;
        if (timeLeft < 0.1f) // if the time runs out
        {
            SceneManager.LoadScene("SampleScene");// Reload SampleScene.

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

    void CountScore()
    {
        score = score + (int)(timeLeft * 10); // calculate the current score with this formula
        Debug.Log("Score ---> " + score);
    }

}
