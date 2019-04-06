using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using Assets.Scripts;


/*
This class is no longer significant because the player is controlled in a different way in the
new game.
 */
public class Player_Move : MonoBehaviour
{

    /*
    This script is not being used in the Bubble Struggle game. We opted to leave this script in the 
    project in case we needed to reference it for anything.
     */

    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;
    public GameObject player;

    private int playerSpeed;
    public static bool facingRight;
    public int playerJumpPower = 1250;
    private float moveX;
    public bool isGrounded;
    private float distanceToBottomPlayer = 0.9f;

    public Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        facingRight = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerRaycast(); // Start the player Raycast.
        PlayerMove(); // Move the player.

    }

    //Move player
    void PlayerMove()
    {
        KeyBoardMovement(); // Trigger keyboard controlls method.
      //  MyoMovements();
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

        playerSpeed = 7; // Set the player speed to 10.
        playerJumpPower = 500;

        // Access the ThalmicMyo component attached to the Myo game object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo>();


        // Vibrate the Myo armband when a fist is made.
        if (thalmicMyo.pose == Pose.Fist ) // Test this. ---------------------------------------------------------
        {
            //&& isGrounded == true
            //  Jump();
       //     moveX = 1.0f;


        //    ExtendUnlockAndNotifyUserAction(thalmicMyo);

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
            
            
            Debug.Log("---> Double tap.");

            ExtendUnlockAndNotifyUserAction(thalmicMyo);
        }
        else if (thalmicMyo.pose == Pose.Rest)
        {
           
            moveX = 0.0f;
        }
        else if(thalmicMyo.pose == Pose.FingersSpread)
        {
            Debug.Log("Shoot");
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
    //    Debug.Log("Flip");

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == Tags.Ground)
        {
            isGrounded = true;
        }
    }

    private void Jump()
    {

        Debug.Log("Facing right ---> " + facingRight);

        if (!facingRight)
        {

             Vector2 jumpDirection = new Vector2(1000f, 100f);
             float jumpFocre = 1200f;

            jumpDirection.x = 100;

            // rb.MovePosition(rb.position + new Vector2(moveX * Time.fixedDeltaTime, moveX * Time.fixedDeltaTime));
            // rb.MovePosition(rb.position + new Vector2(0, 10));
            Debug.Log("Yurt.");
            //GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // Character moves up.
            // GetComponent<Rigidbody2D>().AddForce(Vector2.right * 10000); // Character moves up.
            //  GetComponent<Rigidbody2D>().AddForce(Vector2.MoveTowards(player.transform.position, new Vector2(player.transform.position.x + 10, player.transform.position.y + 10), 10.0f) * 300); // Character moves up.
            GetComponent<Rigidbody2D>().AddForce(jumpDirection.normalized * jumpFocre);

        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // Character moves up.
        }

        //GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // Character moves up.

        isGrounded = false; // Character is not grounded and therefore cannot jump.

        //  isGrounded = false; // Character is not grounded and therefore cannot jump. 
    }

    /* ---------------------------- Origional Jump() method.
    private void Jump()
    {

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // Character moves up.

        isGrounded = false; // Character is not grounded and therefore cannot jump.

        //  isGrounded = false; // Character is not grounded and therefore cannot jump. 
    }
    */

    // Raycast method.
    void playerRaycast()
    {

        RaycastHit2D rayUp = Physics2D.Raycast(transform.position, Vector2.up);
        if (rayUp != null && rayUp.collider != null && rayUp.distance < distanceToBottomPlayer && rayUp.collider.tag == Tags.BreakBox)
        {
            Destroy(rayUp.collider.gameObject); // To destroy the breakable boxes.
        }
        RaycastHit2D rayDown = Physics2D.Raycast(transform.position, Vector2.down); // To kill an enemy when jumped on.
        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomPlayer && rayDown.collider.tag == Tags.Enemy)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);// Move to the right after hit enemy.
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            rayDown.collider.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            rayDown.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            rayDown.collider.gameObject.GetComponent<Enemy_Move>().enabled = false;
        }

        if (rayDown != null && rayDown.collider != null && rayDown.distance < distanceToBottomPlayer && rayDown.collider.tag != Tags.Enemy)
        {
            isGrounded = true; // So the player can bounce on the enemy
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


