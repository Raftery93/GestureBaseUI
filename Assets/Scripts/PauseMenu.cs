using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.Windows.Speech;
using System.Linq;
using System;

public class PauseMenu : MonoBehaviour { // Class to control what happens in the in-game pause menu.

    public static bool IsPaused = false;
    public GameObject pauseMenuUI;
    private LevelsManager manager = new LevelsManager();

    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start(){
        actions.Add("pause", Pause);
        actions.Add("resume", Resume);
        actions.Add("main menu", MainMenu);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        Debug.Log("Speech started");
    }

     private void RecognizedSpeech(PhraseRecognizedEventArgs speech){

        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
	
	// Update is called once per frame
	void Update () {
        //Change for voice command on "pause"
        if (Input.GetKeyDown(KeyCode.Escape)) // If the user presses the escape key while using a keyboard.
        {
            Pause(); // Trigger the pause game method.
        }else if(1 == 2){//Change to on "resume"
            Resume();
        }

        //if(IsPaused == true && MainMenu is said){
            //Load main menu
        //}

    }
    /* Adapted from: https://www.youtube.com/watch?v=JivuXdrIHK0 */
    public void PauseGame() // Method is triggered when the user presses the escape key or the pause UI button.
    {
            if (IsPaused) // If the game is already paused.
            {
                Resume(); // Resume the game.
            }
            else // If the game is not currently paused.
            {
                Pause(); // Activate the pause menu.
            }
            
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Dea-activate the pause menu.
        Time.timeScale = 1f; // Return the time scale to normal(1 second at a time).
        IsPaused = false; // Set the IsPaused variable back to false.
    }

    public void Pause() // Whenever the pause menu is activated.
    {
        pauseMenuUI.SetActive(true); // Set the visibility of the panel to true.
        Time.timeScale = 0f; // Set the time scale to 0 so all the animations and timers appear to pause.
        IsPaused = true; // Set the isPaused variable to true while this menu is displayed.
    }

    public void MainMenu()
    {
        if(IsPaused == true){
            IsPaused = false; // Set the IsPaused variable to false so that is the user goes to main menu then exits the game, the level will start as normal next time around.
            pauseMenuUI.SetActive(false); // De-activate the pause menu.
            Time.timeScale = 1f; // Return the time scale to normal(1 second at a time).
            manager.ChangeLevel(Levels.Main_Menu); // Use the level manager to change the view to the main menu.
        }
    }

    public void Quit()
    {
        Debug.Log("Quit game");
        keywordRecognizer.Stop();
    }
}