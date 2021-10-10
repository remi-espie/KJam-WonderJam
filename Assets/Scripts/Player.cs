using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static List<Player> players = new List<Player>();
    private static bool playersHasActivateAlarm = false;
    private static bool death = false;

    public float timeBeforeDie = 2.0f;

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
    private bool endSection = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Awake()
    {
        defaultGravity = Physics2D.gravity;
        players.Add(this);
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
        if (!endSection)
        {
            float movement = 0.0f;
            if (Input.GetKey(leftMove))
            {
                movement = -1.0f;
            }
            else if (Input.GetKey(rightMove))
            {
                movement = 1.0f;
            }

            Vector3 targetVelocity = new Vector2(movement * speed * Time.fixedDeltaTime, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.01f);
        }
    }

    private void Update()
    {
        CheckPlayers();

        timeBeforeChangeGravity -= Time.deltaTime;
        timeBeforeChangeGravity = Mathf.Max(0.0f, timeBeforeChangeGravity);

        if (Input.GetKeyDown(changeGravity) && timeBeforeChangeGravity == 0.0f && !endSection)
        {
            GravityFlipped = !GravityFlipped;
            timeBeforeChangeGravity = TIMEBEFORECHANGEGRAVITY;
        }   

        if(nbSignals == 0)
        {
            timeBeforeDie -= Time.deltaTime;
            timeBeforeDie = Mathf.Max(0.0f, timeBeforeDie);

            if(timeBeforeDie == 0.0f && !death)
            {
                Death();
            }
        }
        else
        {
            timeBeforeDie = 2.0f;
        }
    }

    public static void CheckPlayers()
    {
        int i = 0;
        while(i < players.Count && players[i].nbSignals > 0)
        {
            i++;
        }

        if(i < players.Count && !death)
        {
            MainCamera.GetInstance().StartAlarm();
            playersHasActivateAlarm = true;
        }
        else if(playersHasActivateAlarm)
        {
            playersHasActivateAlarm = false;
            MainCamera.GetInstance().StopAlarm();
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
        endSection = true;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void StartSection()
    {
        endSection = false;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public static void Death()
    {
        if(!death)
        {
            death = true;
            Time.timeScale = 0.0f;
            players[0].StartCoroutine(players[0].DeathCoroutine());
        }
    }

    private IEnumerator DeathCoroutine()
    {
        yield return new WaitForSecondsRealtime(2.0f);

        MainCamera.GetInstance().StopAlarm();
    }
}   
