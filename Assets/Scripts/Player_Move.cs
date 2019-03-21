using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;

public class Player_Move : MonoBehaviour
{

    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;
    public GameObject player;

    private int playerSpeed;
    public static bool facingRight;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;

    // Use this for initialization
    void Start()
    {

        facingRight = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        PlayerMove(); // Move the player.

    }

    //Move player
    void PlayerMove()
    {
        KeyBoardMovement(); // Trigger keyboard controlls method.
        //MyoMovements();
    }

    void KeyBoardMovement()
    {
        playerSpeed = 10; // Set the player speed to 10.
        moveX = Input.GetAxis("Horizontal");
        //Debug.Log("Move DX ---> " + moveX);

        if (Input.GetButtonDown("Jump") && isGrounded == true) // If the space bar is hit.
        {
            Jump();
        }

        // Player direction.
        if (moveX < 0.0f && facingRight == false) // So the player is facing left when moving left.
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true) // So the player is facing right when moving right.
        {
            FlipPlayer();
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
        moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y); // Move the player.
    }

    void MyoMovements()
    {

        playerSpeed = 5; // Set the player speed to 10.
        playerJumpPower = 70;

        // Access the ThalmicMyo component attached to the Myo game object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();


        // Vibrate the Myo armband when a fist is made.
        if (thalmicMyo.pose == Pose.Fist && isGrounded == true) // Test this. ---------------------------------------------------------
        {
           
            Jump();

          //  ExtendUnlockAndNotifyUserAction (thalmicMyo);

           
        }
        else if (thalmicMyo.pose == Pose.WaveIn)
        {
            
            moveX = -1.0f;
            

            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        }
        else if (thalmicMyo.pose == Pose.WaveOut)
        {
           
            moveX = 1.0f;
           

            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        }
        else if (thalmicMyo.pose == Pose.DoubleTap)
        {

            
            Debug.Log("Double tap.");

            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        }
        else if (thalmicMyo.pose == Pose.Rest)
        {
           
            moveX = 0.0f;
        }


        // Player direction.
        if (moveX < 0.0f && facingRight == false) // So the player is facing left when moving left.
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && facingRight == true) // So the player is facing right when moving right.
        {
            FlipPlayer();
        }
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(
        moveX * playerSpeed, player.GetComponent<Rigidbody2D>().velocity.y); // Move the player.
     //   Debug.Log("Moving X ---> " + moveX);

    }

    private void FlipPlayer()
    {
        // Flip code.
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale; // Simply puts the game character facing the other way.
        Debug.Log("Flip");

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }

    private void Jump()
    {
       
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // Character moves up.

            isGrounded = false; // Character is not grounded and therefore cannot jump.

          //  isGrounded = false; // Character is not grounded and therefore cannot jump. 
    }

//>>>>>>> d944c4ce6604680eca92ac7efdb8c11f64ff7f04

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


