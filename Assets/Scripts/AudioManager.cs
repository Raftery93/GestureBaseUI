using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;
using Assets.Scripts;

public class AudioManager : MonoBehaviour // Adapted from - https://www.youtube.com/watch?v=6OT43pvUyfY .
{

    public Sound[] sounds; // So that we can manage all of our audio files from this class.

    public static AudioManager instance; // Create a singleton instance so all levels have access to the same AudioManager.


    void Awake(){

        if(instance == null){ // If there is not an instance.
            instance = this; // Return this object.
        }else{
            Destroy(gameObject); // Otherwise destroy this object.
            return;
        }

        DontDestroyOnLoad(gameObject); // So the AudioManager persists throughout all of the scenes.
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
        /*
        Start playing the background theme as soon as this script is started,
        this way the background theme will continue to play on a loop, un-interrupted
         throughout all of the levels.
         */
        Play(Audio.Theme);  
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // Call back function for finding the audio source in the array.
        if (s == null)
        {
            return;
        }
        s.source.Play(); // Play the audio.
       
       
    }

}
