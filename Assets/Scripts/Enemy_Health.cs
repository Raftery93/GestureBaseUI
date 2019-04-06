using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class is no longer significant because the new game does not contain an enemy object.
 */
public class Enemy_Health : MonoBehaviour
{
   
    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -20)
        {
            Destroy(gameObject); // Simply destroy the enemy object when it falls off the platform.
        }

    }
}
