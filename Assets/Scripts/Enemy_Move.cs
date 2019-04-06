using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Enemy_Move : MonoBehaviour
{

    public int EnemySpeed;
    public int XMoveDirection;
    public float hitDistance = 0.5f;


    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(XMoveDirection, 0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;

        if (hit.distance < hitDistance)
        {
            FlipEnemy();
            if (hit.collider.tag == Tags.Player) // If the enemy hits the player.
            {
               
                Destroy(hit.collider.gameObject); // Kill the player and redirect to levels menu.
              
            }
        }
    }

    void FlipEnemy()
    {
        if(XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
