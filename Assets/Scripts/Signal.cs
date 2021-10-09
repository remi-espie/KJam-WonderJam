using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("Player"))
        {
            collision.gameObject.SendMessage("AddSignal");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            collision.gameObject.SendMessage("RemoveSignal");
        }
    }
}
