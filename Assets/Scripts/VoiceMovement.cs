using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class VoiceMovement : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;

    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    void Start(){
        actions.Add("right", Right);
        actions.Add("left", Left);
        //actions.Add("down", Down);
        //actions.Add("back", Back);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

        keywordRecognizer.Stop();

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
}
