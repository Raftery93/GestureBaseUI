using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    public Vector2 startForce;

    public GameObject nextBall;

    public GameObject[] balls;
    Scene m_Scene;
    string sceneName;





    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(startForce, ForceMode2D.Impulse);
        m_Scene = SceneManager.GetActiveScene(); // get a handle on the active scene
        sceneName = m_Scene.name; // get a handle on the active scenes name
    }

    public void Split()
    {
       
        

        if (nextBall != null)
        {
            Debug.Log("Scene ---> " + sceneName);

            if (sceneName == "Bubble1" && nextBall.name == "Ball4")
            {
                //Do nothing.
            }
            else
            {
                GameObject ball1 = Instantiate(nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
                GameObject ball2 = Instantiate(nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

                ball1.GetComponent<BallMove>().startForce = new Vector2(2f, 5f);
                ball2.GetComponent<BallMove>().startForce = new Vector2(-2f, 5f);
            }
         
           
        }
      

        Destroy(gameObject);
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
