﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hook_Collission : MonoBehaviour
{


    public static int i = 0;
    Scene m_Scene;
    string sceneName;

    void Start()
    {
        
        m_Scene = SceneManager.GetActiveScene(); // get a handle on the active scene
        sceneName = m_Scene.name; // get a handle on the active scenes name
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        

        // Use an i flag.
        Chain.IsFired = false;

        if (col.tag == "Ball")
        {
          

            Debug.Log("Ball ---> " + i);
            col.GetComponent<BallMove>().Split();
           
           
        }
    }
}
