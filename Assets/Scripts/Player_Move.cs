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
    }

    void KeyBoardMovement()
    {
        playerSpeed = 10; // Set the player speed to 10.
        moveX = Input.GetAxis("Horizontal");
        Debug.Log("Move DX ---> " + moveX);

        if (Input.GetButtonDown("Jump")) // If the space bar is hit.
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

    private void FlipPlayer()
    {
        // Flip code.
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale; // Simply puts the game character facing the other way.
        Debug.Log("Flip");

    }

    private void Jump()
    {
       
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // Character moves up.
          //  isGrounded = false; // Character is not grounded and therefore cannot jump.

        
        
    }

}


