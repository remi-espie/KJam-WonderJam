using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private static List<Player> players = new List<Player>();
    private static bool playersHasActivateAlarm = false;
    private static bool death = false;

    public Text timeBeforeDieText;
    private float timeBeforeDie = 2.0f;

    public static bool gravityFlipped = false;
    Vector2 defaultGravity;

    private float speed = 300.0f;
    private Vector3 velocity;

    private Rigidbody2D rb;

    public KeyCode leftMove;
    public KeyCode rightMove;
    public KeyCode changeGravity;

    private readonly float TIMEBEFORECHANGEGRAVITY = 0.75f;
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
        Player.AddPlayer(this);
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

            SpriteRenderer spr = GetComponent<SpriteRenderer>();
            if(movement < 0.0f)
            {
                spr.flipX = true;
            }
            else if(movement > 0.0f)
            {
                spr.flipX = false;
            }

            if(Physics2D.gravity.y > 0.0f)
            {
                spr.flipY = true;
            }
            else if (Physics2D.gravity.y < 0.0f)
            {
                spr.flipY = false;
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

        timeBeforeDieText.text = timeBeforeDie.ToString("F2");
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
        else if(playersHasActivateAlarm && !death)
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

    public static void AddPlayer(Player player)
    {
        players.Add(player);

        for(int i = 0; i < players.Count; i++)
        {
            for(int j = i; j < players.Count; j++)
            {
                Physics2D.IgnoreCollision(players[i].GetComponent<CapsuleCollider2D>(), players[j].GetComponent<CapsuleCollider2D>());
            }
        }
    }
}   
