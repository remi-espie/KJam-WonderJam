using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public TextElement timer;
    
    public static float timeBeforeDie = 10.0f;

    public static bool gravityFlipped = false;
    Vector2 defaultGravity;

    private float speed = 300.0f;
    private Vector3 velocity;

    private Rigidbody2D rb;

    public KeyCode leftMove;
    public KeyCode rightMove;
    public KeyCode changeGravity;

    private readonly float TIMEBEFORECHANGEGRAVITY = 2.0f;
    private float timeBeforeChangeGravity;

    private uint nbSignals = 0;
    public float timeRemaining = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        defaultGravity = Physics2D.gravity;
    }

    public bool GravityFlipped
    {
        get => gravityFlipped;
        set
        {
            gravityFlipped = value;
            Physics2D.gravity = defaultGravity * (value ? -1 : 1);
        }
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
            GravityFlipped = !GravityFlipped;
            timeBeforeChangeGravity = TIMEBEFORECHANGEGRAVITY;
        }

        if (nbSignals<=0)
        {
            timeRemaining -= Time.deltaTime;
            //timer.text = Math.Round(timeRemaining).ToString();
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
