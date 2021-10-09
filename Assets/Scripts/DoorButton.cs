using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Sprite openSprite;
    public Sprite closeSprite;

    public void Activate()
    {
        GetComponent<SpriteRenderer>().sprite = openSprite;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void Desactivate()
    {
        GetComponent<SpriteRenderer>().sprite = closeSprite;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
