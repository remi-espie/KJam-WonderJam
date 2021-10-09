using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorKey door;

    public void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        door.SendMessage("Open");
        Destroy(transform.gameObject);
    }
=======
        door.sprite = openDoor;
        door.GetComponent<BoxCollider2D>().enabled = false;
        Destroy(gameObject);
    }   
>>>>>>> 44995e1356507ba4dd02380ce62af3cca7f53377
}