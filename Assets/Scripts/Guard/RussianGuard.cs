using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RussianGuard : MonoBehaviour
{
    private float speed = 100.0f;
    private Vector3 velocity;

    private Rigidbody2D rb;

    private Boolean direction = false;
    private bool upsideDown = false;
    private readonly float TIMEBEFORECHANGEGRAVITY = 2.0f;
    private float timeBeforeChangeGravity;

    public float speedMultiplier;

    private uint nbSignals = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void turnAroundKazuya()
    {
        direction = !direction;
        Debug.Log("GUARD: Turning around now!");
        transform.localScale = Vector3.Scale(new Vector3(-1, 1, 1), transform.localScale);
    }

    void FixedUpdate()
    {
        float movement = 0.0f;
        if (direction)
        {
            movement = -1.0f * speedMultiplier;
        }
        else if (!direction)
        {
            movement = 1.0f * speedMultiplier;
        }

        Vector3 targetVelocity = new Vector2(movement * speed * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.01f);
    }

    private void Update()
    {
        if (Player.gravityFlipped==true && !upsideDown)
        {
            upsideDown = true;
            transform.localScale = Vector3.Scale(new Vector3(1, -1, 1), transform.localScale);
        }
        if (Player.gravityFlipped==false && upsideDown)
        {
            upsideDown = false;
            transform.localScale = Vector3.Scale(new Vector3(1, -1, 1), transform.localScale);
        }
    }

    public bool isAlive()
    {
        return nbSignals > 0;
    }

    public void AddSignal()
    {
        nbSignals++;
    }

    public void RemoveSignal()
    {
        nbSignals--;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            Spike_Collision.Death();
        }
    }
}
