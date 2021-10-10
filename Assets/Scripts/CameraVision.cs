using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVision : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("Player"))
        {
            _spriteRenderer.color = Color.red;
            collision.gameObject.SendMessage("Death");
        }
    }
}
