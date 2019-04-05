using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class HelpVoice : MonoBehaviour
{

     private LevelsManager levelManager; // Get handle on LevelManager object.

    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();


    // Start is called before the first frame update
    void Start()
    {
        actions.Add("back", Return);
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
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
