using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public SpriteRenderer key;
    public SpriteRenderer door;
    public Sprite openDoor;
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
            door.sprite = openDoor;
            door.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject);
    }   
}