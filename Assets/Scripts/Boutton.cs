using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boutton : MonoBehaviour
{
    public GameObject target;

    public Sprite activateSprite;
    public Sprite disableSprite;

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
        if(collision.gameObject.tag.Contains("Player") || collision.gameObject.tag.Contains("Guard"))
        {
            target.SendMessage("Activate");
            GetComponent<SpriteRenderer>().sprite = activateSprite;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Player") || collision.gameObject.tag.Contains("Guard"))
        {
            target.SendMessage("Desactivate");
            GetComponent<SpriteRenderer>().sprite = disableSprite;
        }
    }
}
