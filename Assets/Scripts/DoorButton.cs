using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public Sprite openSprite1;
    public Sprite openSprite2;
    public Sprite openSprite3;
    public Sprite closeSprite;

    private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Activate()
    {
        StartCoroutine(Activate2());
    }

    IEnumerator Activate2()
    {
        GetComponent<SpriteRenderer>().sprite = closeSprite;
        yield return new WaitForSeconds(0.5f);
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = openSprite3;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = openSprite2;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = openSprite1;
    }

    public void Desactivate()
    {
        StartCoroutine(Desactivate2());
    }
    
    IEnumerator Desactivate2()
    {
        GetComponent<SpriteRenderer>().sprite = openSprite1;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = openSprite2;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = openSprite3;
        yield return new WaitForSeconds(0.5f);
        GetComponent<SpriteRenderer>().sprite = closeSprite;
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
