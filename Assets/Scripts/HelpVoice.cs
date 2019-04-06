using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class HelpVoice : MonoBehaviour // Class that controls the speech recognition on the help scene.
{

     private LevelsManager levelManager; // Get handle on LevelManager object.

    private KeywordRecognizer keywordRecognizer; // Get a reference to the Windows KeywordRecognizer.

    /*
    Create a dictionary to store the word/phrase to action mappings.
     */
    private Dictionary<string, Action> actions = new Dictionary<string, Action>(); 


    // Start is called before the first frame update
    void Start()
    {
        actions.Add("back", Return); // Of the user says "back", call the Return() method.
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start(); // Start listening for words/phrases.
        Debug.Log("Speech started");
        levelManager = new LevelsManager();// Create new instance of level manager.
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    public void Return(){
        //Return to main menu
        levelManager.ChangeLevel(Levels.Main_Menu);// Change level when this method is triggered.
    }
}
