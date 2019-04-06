using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This class is no longer significant because the the new game has different lose 
conditions.
 */
public class Player_Health : MonoBehaviour
{
    public int deathPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < deathPoint)
        {
            Die();
        }
    }

    void Die()
    {
      //  Debug.Log("Die");
    }
}
