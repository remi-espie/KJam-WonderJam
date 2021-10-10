using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boutton : MonoBehaviour
{
    public GameObject target;

    public Sprite activateSprite;
    public Sprite disableSprite;

    private Boolean player1Here = false;
    private Boolean player2Here = false;
    private Boolean guardHere = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1")) player1Here = true;
        if (collision.gameObject.CompareTag("Player2")) player2Here = true;
        if (collision.gameObject.CompareTag("Guard")) guardHere = true;
        if (player1Here ^ player2Here ^ guardHere)
        {
            target.SendMessage("Activate");
            GetComponent<SpriteRenderer>().sprite = activateSprite;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1")) player1Here = false;
        if (collision.gameObject.CompareTag("Player2")) player2Here = false;
        if (collision.gameObject.CompareTag("Guard")) guardHere = false;
        if (!player1Here && !player2Here && !guardHere)
        {
            target.SendMessage("Desactivate");
            GetComponent<SpriteRenderer>().sprite = disableSprite;
        }
    }

}
