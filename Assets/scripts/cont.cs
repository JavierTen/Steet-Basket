﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cont : MonoBehaviour
{
    public static cont instance; 

    public Action player;
    public Transform ball;
    public Transform canasta;
    public bool canScore;

    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        if(player.holdingBall == false)
        {
            if(ball.position.y > canasta.position.y && canScore == false)
            {
                canScore = true;
                Debug.Log("canastar"); 
            }
        }
    }
}
