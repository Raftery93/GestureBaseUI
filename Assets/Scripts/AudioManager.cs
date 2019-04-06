using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;
using Assets.Scripts;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds; // So that we can manage all of our audio files from this class.

    public static AudioManager instance;


    void Awake(){

        if(instance == null){
            instance = this;
        }else{
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds) // Loop through each audio source and give it the following properties.
        {
            s.source = gameObject.AddComponent<AudioSource>(); // Add Audio source component.

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        Play(Audio.Theme); // Anytime the audion manager is in a level, automatically play the main theme at the start of the level.
    }

    public void Play(string name)
    {
      //  Debug.Log("Play " + name);
        Sound s = Array.Find(sounds, sound => sound.name == name); // Call back function for finding the audio source in the array.
        if (s == null)
        {
           // Debug.Log("Sound " + name + " does not exist");
            return;
        }
        s.source.Play(); // Play the audio.
       
       
    }

}
