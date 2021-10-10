﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianGuard : MonoBehaviour
{
    private float speed = 100.0f;
    private Vector3 velocity;

    private Rigidbody2D rb;

    private Boolean direction = false;
    private readonly float TIMEBEFORECHANGEGRAVITY = 2.0f;
    private float timeBeforeChangeGravity;

    private uint nbSignals = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void turnAroundKazuya()
    {
        direction = !direction;
        Debug.Log("GUARD: Turning around now!");
    }

    void FixedUpdate()
    {
        float movement = 0.0f;
        if (direction)
        {
            movement = -1.0f;
        }
        else if (!direction)
        {
            movement = 1.0f;
        }

        Vector3 targetVelocity = new Vector2(movement * speed * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.01f);
    }

    private void Update()
    {
        
    }

    public bool isAlive()
    {
        return nbSignals > 0;
    }

    public void AddSignal()
    {
        nbSignals++;
    }

    public void RemoveSignal()
    {
        nbSignals--;
    }
}
