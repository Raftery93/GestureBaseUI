using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class VoiceControl : MonoBehaviour // Class to control the voice recognition for navigation.
{

    private LevelsManager manager;
    private KeywordRecognizer keywordRecognizer;

    /*
    Create a dictionary to map the included words/phrases to actions.
     */
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start(){
        manager = new LevelsManager();

        actions.Add("right", Right);
        actions.Add("left", Left);
        actions.Add("play", Play);
        actions.Add("start", Play);
        actions.Add("quit", Quit);
        actions.Add("exit", Quit);
        actions.Add("main menu", MainMenu);
        actions.Add("back", MainMenu);
        actions.Add("return", MainMenu);
        actions.Add("level one", LevelOne);
        actions.Add("one", LevelOne);
        actions.Add("level two", LevelTwo);
        actions.Add("two", LevelTwo);
        actions.Add("level three", LevelThree);
        actions.Add("three", LevelThree);
        actions.Add("level four", LevelFour);
        actions.Add("four", LevelFour);
        actions.Add("level five", LevelFive);
        actions.Add("five", LevelFive);
        actions.Add("help", Help);
       
        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        Debug.Log("Speech started");

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){

        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Right(){
        transform.Translate(1, 0, 0);
    }

    private void Left(){
        transform.Translate(-1, 0, 0);
    }

    private void Play(){
       manager.ChangeLevel(Levels.Levels_Menu);
    }

    private void Quit(){
        Debug.Log("Quit!!");
        keywordRecognizer.Stop();
    }

    private void MainMenu(){
        manager.ChangeLevel(Levels.Main_Menu);
    }

    private void LevelOne(){
        manager.ChangeLevel(Levels.Level_1);
    }

    private void LevelTwo(){
        manager.ChangeLevel(Levels.Level_2);
    }

    private void LevelThree(){
        manager.ChangeLevel(Levels.Level_3);
    }

    private void LevelFour(){
        manager.ChangeLevel(Levels.Level_4);
    }

    private void LevelFive(){
        manager.ChangeLevel(Levels.Level_5);
    }

    private void Help(){
        manager.ChangeLevel(Levels.Help);
    }
}
