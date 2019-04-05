using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class VoiceControl : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start(){
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
        //actions.Add("down", Down);
        //actions.Add("back", Back);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
        Debug.Log("Speech started");
       // keywordRecognizer.Stop();

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
        SceneManager.LoadScene("LevelsMenu");
    }

    private void Quit(){
        Debug.Log("Quit!!");
    }

    private void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    private void LevelOne(){
        SceneManager.LoadScene("Bubble1");
    }

    private void LevelTwo(){
        SceneManager.LoadScene("Bubble2");
    }

    private void LevelThree(){
        SceneManager.LoadScene("Bubble3");
    }

    private void LevelFour(){
        SceneManager.LoadScene("Bubble4");
    }

    private void LevelFive(){
        SceneManager.LoadScene("Bubble5");
    }
}
