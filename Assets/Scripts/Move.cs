using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int speed = 10;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(inputX * speed, inputY * speed);
    }
}
