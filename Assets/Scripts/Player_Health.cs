using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
<<<<<<< HEAD
        //Debug.Log("Die");
=======
      //  Debug.Log("Die");
>>>>>>> a8cd8b6c2366282fb562e6bd2069130c8ccce14d
    }
}
