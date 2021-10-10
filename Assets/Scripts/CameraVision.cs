using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVision : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Contains("Player"))
        {
<<<<<<< HEAD
            MainCamera.GetInstance().StartAlarm();
            Player.Death();
=======
            Debug.Log("PLayer has died!!!!  vy camera");
            collision.gameObject.SendMessage("Death");
>>>>>>> 85c22385d8dbe4b85fde4bb847a616abc25d5246
        }
    }
}
