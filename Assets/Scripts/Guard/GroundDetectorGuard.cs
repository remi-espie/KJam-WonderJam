using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GroundDetectorGuard : MonoBehaviour
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

    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Tilemap")
        {
            Debug.Log("Asking the guard to turn around");
            parent.SendMessage("turnAroundKazuya");
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        print("Start of collision");
    }

    public void youdienow()
    {
        Destroy(parent);
        Destroy(this);
    }
}
