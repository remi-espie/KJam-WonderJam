using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WallDetectorGuard : MonoBehaviour
{
    public GameObject parent;
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
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Tilemap")
        {
            Debug.Log("Asking the guard to turn around");
            parent.SendMessage("turnAroundKazuya");
        }
    }
}
