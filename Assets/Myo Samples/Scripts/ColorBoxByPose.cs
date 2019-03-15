using UnityEngine;
using System.Collections;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

// Change the material when certain poses are made with the Myo armband.
// Vibrate the Myo armband when a fist pose is made.
public class ColorBoxByPose : MonoBehaviour
{

    

    // Myo game object to connect with.
    // This object must have a ThalmicMyo script attached.
    public GameObject myo = null;
    public GameObject player;



    public int playerSpeed;
    public static bool facingRight;
    public int playerJumpPower = 70;
    public float moveX;
    


    // Materials to change to when poses are made.
  //  public Material waveInMaterial;
 //   public Material waveOutMaterial;
 //   public Material doubleTapMaterial;

    // The pose from the last update. This is used to determine if the pose has changed
    // so that actions are only performed upon making them rather than every frame during
    // which they are active.
    /////  private Pose _lastPose = Pose.Unknown;
    /// <summary>
    ///   // Use this for initialization
    void Start()
    {

        facingRight = false;

    }
    /// </summary>

    // Update is called once per frame.
    void FixedUpdate()
    {

        playerSpeed = 5; // Set the player speed to 10.

        // Access the ThalmicMyo component attached to the Myo game object.
        ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

        // Check if the pose has changed since last update.
        // The ThalmicMyo component of a Myo game object has a pose property that is set to the
        // currently detected pose (e.g. Pose.Fist for the user making a fist). If no pose is currently
        // detected, pose will be set to Pose.Rest. If pose detection is unavailable, e.g. because Myo
        // is not on a user's arm, pose will be set to Pose.Unknown.
   /////     if (thalmicMyo.pose != _lastPose) {
   /////         _lastPose = thalmicMyo.pose;

            // Vibrate the Myo armband when a fist is made.
            if (thalmicMyo.pose == Pose.Fist) {
                //  thalmicMyo.Vibrate (VibrationType.Medium);
                Debug.Log("Jump");

            Jump();

              //  ExtendUnlockAndNotifyUserAction (thalmicMyo);

            // Change material when wave in, wave out or double tap poses are made.
            } else if (thalmicMyo.pose == Pose.WaveIn) {
                // renderer.material = waveInMaterial;
                // int moveX = (int)Pose.WaveIn;
                moveX = -1.0f;
         //       Debug.Log(moveX);

                ExtendUnlockAndNotifyUserAction (thalmicMyo);
            } else if (thalmicMyo.pose == Pose.WaveOut) {
                //renderer.material = waveOutMaterial;
                //int moveX = (int)Pose.WaveIn;
                moveX = 1.0f;
      //          Debug.Log(moveX);
               // Debug.Log("Wave out.");

                ExtendUnlockAndNotifyUserAction (thalmicMyo);
            } else if (thalmicMyo.pose == Pose.DoubleTap) {
            
                //renderer.material = doubleTapMaterial;
                Debug.Log("Double tap.");

                ExtendUnlockAndNotifyUserAction (thalmicMyo);
            }
            else if (thalmicMyo.pose == Pose.Rest)
            {
            //      Debug.Log("Do nothing.");
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
            Debug.Log("Moving X ---> " + moveX);


        /////   }
    }

    private void FlipPlayer()
    {
        // Flip code.
        facingRight = !facingRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale; // Simply puts the game character facing the other way.
      //  Debug.Log("Flip");

    }

    private void Jump()
    {

        GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpPower); // Character moves up.
                                                                            //  isGrounded = false; // Character is not grounded and therefore cannot jump.

    }





    // Extend the unlock if ThalmcHub's locking policy is standard, and notifies the given myo that a user action was
    // recognized.
    void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
    {
        ThalmicHub hub = ThalmicHub.instance;

        if (hub.lockingPolicy == LockingPolicy.Standard) {
            myo.Unlock (UnlockType.Timed);
        }

        myo.NotifyUserAction ();
    }

    
}
