using System.Collections;
using System.Collections.Generic;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BubbleMove : MonoBehaviour // Class controls the Players behaviour.
{
    private LevelsManager manager; // Reference to the level manager so scenes can be easily changed.
    private GameObject myo = null; // To get a handle on the Myo armband.
    public float playerSpeed = 7f; // Initialize the players speed.

    public Rigidbody2D rb; // Player must have a rigid body reference.

    private float movement = 0f; // Initialize the players movement to 0.


    public static int lives; // Reference the number of lives the player has.

    void Start()
    {
       
        manager = new LevelsManager();
        myo = GameObject.FindWithTag(Tags.Myo); // Find the Myo armband.
        lives = 3; // Set the lives to 3.
    }


    // Update is called once per frame
    void Update()
    {
        /*
        Allows the user to still play the game with keyboard keys, this
        is incase the player does not have a Myo atmband or if the Myo
        armband is just warming up.
         */
        movement = Input.GetAxisRaw("Horizontal") * playerSpeed; 
    }

    void FixedUpdate()
    {
        Move(); // Call the method that moves the player with keys.
        MyoMove(); // Call the method that moves the player with Myo.
    }

    void Move()
    {
        rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
    }

    void MyoMove()
    {
        // Access the ThalmicMyo component attached to the Myo game object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();

        if (thalmicMyo.pose == Pose.WaveIn)
        {
            /*
            If the user waves in, move the Player to the left.
             */
            movement = -1.0f * playerSpeed;
        }
        else if(thalmicMyo.pose == Pose.Fist)
        {
            /*
            If the user makes a fist, shoot the chain.
             */
            Chain.IsFired = true;
        }
        else if (thalmicMyo.pose == Pose.WaveOut)
        {
            /*
            If the user waves out, move the player to the right.
             */
            movement = 1.0f * playerSpeed;
        }
        else if (thalmicMyo.pose == Pose.Rest)
        {
            /*
            If the user's arm is resting, set the movement to 0 so the player stops moving.
             */
            movement = 0.0f;
        }
        else if (thalmicMyo.pose == Pose.FingersSpread)
        { // Sometimes the fist gesture was being confused for the fingers spread gesture.
            Chain.IsFired = true;
        }
        rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime, 0f));
    }

    /*
    Whenever something collides with the player, this method isn't used anymore because
    the collider on the player was changed to a trigger.
     */
    void OnCollisionEnter2D(Collision2D col) 
    {
        if (col.collider.tag == Tags.Ball)
        {
          
            FindObjectOfType<AudioManager>().Play(Audio.Ouch);
            if(lives < 1){

                Debug.Log("HIT!");
                manager.ChangeLevel(Levels.Levels_Menu); // So any time the player dies, they get redirected back to the levels menu.

            }

            lives--;
            
        }

    }

    /*
    Whenever something triggers the collider on the player. The collider was changed to a trigger on
    the player to allow the bubbles to pass through the player, still register a collision, but not
    play out the physics of the bubble hitting the player.
     */
    void OnTriggerEnter2D(Collider2D col){

         if (col.tag == Tags.Ball){
           FindObjectOfType<AudioManager>().Play(Audio.Ouch); // Play the "Ouch" audio whenever the player is hit by a bubble.
           if(lives <= 1){ // If the player has no more lives.
               manager.ChangeLevel(Levels.Levels_Menu); // So any time the player dies, they get redirected back to the levels menu.
           }
            lives--; // Decrement the amount of lives left.
         }
        
    }

    // Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
    // recognized.
    void ExtendUnlockAndNotifyUserAction(ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard)
        {
            myo.Unlock(UnlockType.Timed);
        }

        myo.NotifyUserAction();
    }
}
