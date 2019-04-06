using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound 
{
   public string name; // Each sound needs a name.

   public AudioClip clip; // Each sound has an audio clip.

   [Range(0f, 1f)]
   public float volume; // Give each sound a range for volume.

   [Range(0.1f,3)]
   public float pitch; // Give each sound a pitch.

   [HideInInspector]
   public AudioSource source; // Give each sound an audio source.

   public bool loop; // Set whether or not the sound will loop.

}
