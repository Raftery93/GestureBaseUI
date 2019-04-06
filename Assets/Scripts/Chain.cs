using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Chain : MonoBehaviour // Class that controls the behaviour of the chain.
{
    public Transform player; // Get a reference to the players Transform.

    public float speed = 3f; // Give the chain a speed.

    public static bool IsFired; // The chain can't be fired multiple times at once.

    // Start is called before the first frame update
    void Start()
    {
        IsFired = false; // So the chain does not fire when the game begins.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Only if the user is using the keyboard controls.
        {
            IsFired = true;
        }

        if (IsFired) // If the chain has been fired.
        {
            transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed; // Shoot the chain into the air.
            FindObjectOfType<AudioManager>().Play(Audio.Shoot); // Play the audio for the chain being fired.
        }
        else
        {
            /*
            Otherwise, simply follow the player around the scene.
             */
            transform.position = player.position;
            transform.localScale = new Vector3(1f, 0f, 1f);
        }

    }
}
