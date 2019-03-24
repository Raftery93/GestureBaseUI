using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook_Collission : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Chain.IsFired = false;

        if (col.tag == "Ball")
        {
            Debug.Log("Ball");
            col.GetComponent<BallMove>().Split();
        }
    }
}
