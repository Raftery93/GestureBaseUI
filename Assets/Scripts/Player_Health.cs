﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Health : MonoBehaviour
{

    public int health;
    public bool hasDied;

    // Start is called before the first frame update
    void Start()
    {
        hasDied = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDied == true)
        {
            Debug.Log("Player has died");

        }
    }
}
