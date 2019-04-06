using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class BallMove : MonoBehaviour // Class that controls the behaviour of the bubbles.
{
    public Vector2 startForce; // Give the bubbles a force.

    /*
    Supply each bubble with the smaller bubble(if any) that the current bubble 
    will burst/split into.
     */
    public GameObject nextBall;

    public GameObject[] balls; // To get a reference to the amount of bubbles still in the scene.
    Scene m_Scene; // To get a handle on the current scene.
    string sceneName; // To get a handle on the current scenes name.





    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(startForce, ForceMode2D.Impulse);
        m_Scene = SceneManager.GetActiveScene(); // Get a handle on the active scene.
        sceneName = m_Scene.name; // Get a handle on the active scenes name.
    }

    public void Split() // To be called when the Hook hits a bubble.
    {
       
        

        if (nextBall != null) // While there are smaller bubble to pop into.
        {
           
            if (sceneName == Levels.Level_1 && nextBall.name == Bubbles.Bubble_4)
            {
                /*
                Do nothing.
                If it is the first level and the player has hit Bubble 4, do not split
                because the first level only allows bubbles to be split three times.
                 */

            }
            else if (sceneName == Levels.Level_3 && nextBall.name == Bubbles.Bubble_2)
            {
                /*
                If it is the third level, and the player has popped Bubble 2, split that bubble
                into 3 smaller bubbles.
                 */
                GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);
                GameObject ball3 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                ball1.GetComponent<BallMove>().startForce = new Vector2(2f, 5f);
                ball2.GetComponent<BallMove>().startForce = new Vector2(-2f, 5f);
                ball3.GetComponent<BallMove>().startForce = new Vector2(-3f, 5f);
            }

            else if (sceneName == Levels.Level_4 && (nextBall.name == Bubbles.Bubble_2 || nextBall.name == Bubbles.Bubble_4))
            {
                /*
                If it is the fourth level, and the player has popped either Bubble 2 or Bubble 3,
                split that bubble into 3 smaller bubbles.
                 */
                GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);
                GameObject ball3 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                ball1.GetComponent<BallMove>().startForce = new Vector2(2f, 5f);
                ball2.GetComponent<BallMove>().startForce = new Vector2(-2f, 5f);
                ball3.GetComponent<BallMove>().startForce = new Vector2(-3f, 5f);
            }

            else if (sceneName == Levels.Level_5)
            {
                /*
                 If it is the fifth level, all bubbles get popped into 3 smaller bubbles.
                 */
                GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);
                GameObject ball3 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                ball1.GetComponent<BallMove>().startForce = new Vector2(2f, 5f);
                ball2.GetComponent<BallMove>().startForce = new Vector2(-2f, 5f);
                ball3.GetComponent<BallMove>().startForce = new Vector2(-3f, 5f);
            }

            else // The default is level 2.
            {
                /*
                Split all bubbles into 2 smaller bubbles.
                 */
                GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                ball1.GetComponent<BallMove>().startForce = new Vector2(2f, 5f);
                ball2.GetComponent<BallMove>().startForce = new Vector2(-2f, 5f);
            }
          
        }
      

        Destroy(gameObject); // Destroy the bubble that was just hit.
     
    }

}
