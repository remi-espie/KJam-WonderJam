using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("Player"))
        {
            Debug.Log("PLayer has died!!!!  vy camera");
            collision.gameObject.SendMessage("Death");
        }
    }
}
