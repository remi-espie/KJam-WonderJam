using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static float timeBeforeDie = 10.0f;

    private float speed = 300.0f;
    private Vector3 velocity;

    private Rigidbody2D rb;

    public KeyCode leftMove;
    public KeyCode rightMove;
    public KeyCode changeGravity;

    private readonly float TIMEBEFORECHANGEGRAVITY = 0.25f;
    private float timeBeforeChangeGravity;

    private uint nbSignals = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float movement = 0.0f;
        if(Input.GetKey(leftMove))
        {
            movement = -1.0f;
        }
        else if(Input.GetKey(rightMove))
        {
            movement = 1.0f;
        }

        Vector3 targetVelocity = new Vector2(movement * speed * Time.fixedDeltaTime, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.01f);
    }

    private void Update()
    {
        timeBeforeChangeGravity -= Time.deltaTime;
        timeBeforeChangeGravity = Mathf.Max(0.0f, timeBeforeChangeGravity);

        if(Input.GetKeyDown(changeGravity) && timeBeforeChangeGravity == 0.0f)
        {
            Physics2D.gravity *= -1.0f;
            timeBeforeChangeGravity = TIMEBEFORECHANGEGRAVITY;
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

    public void EndSection()
    {
        transform.gameObject.SetActive(false);
    }

    public void StartSection()
    {
        transform.gameObject.SetActive(true);
    }
}
