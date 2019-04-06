using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class Hook_Collission : MonoBehaviour // Class to control what happens when the hook collides with something.
{

    Scene m_Scene; // To get a reference to the current scene.
    string sceneName; // To get a handle on the current scene's name.

    void Start()
    {
        m_Scene = SceneManager.GetActiveScene(); // Get a handle on the active scene.
        sceneName = m_Scene.name; // Get a handle on the active scenes name.
    }
    void OnTriggerEnter2D(Collider2D col) // When something triggers the collider on the hook.
    {
        
        Chain.IsFired = false; // Stop the chain firing.

        if (col.tag == Tags.Ball) // If it has collided with a bubble.
        {
        
            col.GetComponent<BallMove>().Split(); // Split the bubble.
            FindObjectOfType<AudioManager>().Play(Audio.Pop); // Play the "Pop" audio clip.
               
        }

        if(col.tag == Tags.Heart){ // If it has collided with the heart.
           FindObjectOfType<AudioManager>().Play(Audio.Life); // Play the "Life" audio clip.
           Destroy(col.gameObject); // Destroy the heart.
           BubbleMove.lives++; // Increment the lives by one.
        }
    }
}
