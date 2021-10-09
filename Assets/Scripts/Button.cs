﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public SpriteRenderer plate;
    public SpriteRenderer door;
    public Sprite openDoor;
    public Sprite pushedButton;

    private bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collider2D)
    {
        print("test"); 
        
        if (!locked) {
            locked = false;
            plate.sprite = pushedButton;
            door.sprite = openDoor;
            door.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }
}
