using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public SpriteRenderer plate;
    public SpriteRenderer door;
    public Sprite openDoor;
    public Sprite pushedButton;

    private bool _locked = true;

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (_locked) {
            _locked = false;
            plate.sprite = pushedButton;
            door.sprite = openDoor;
            door.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
