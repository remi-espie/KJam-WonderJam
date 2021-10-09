using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorKey door;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        door.SendMessage("Open");
        Destroy(transform.gameObject);
    }
}