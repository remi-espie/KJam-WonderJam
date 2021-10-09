using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    private float speed = 300.0f;
    private Vector3 velocity;

    private Rigidbody2D rb;
    private ConstantForce2D gravity;

    public KeyCode leftMove;
    public KeyCode rightMove;
    public KeyCode changeGravity;

    private readonly float TIMEBEFORECHANGEGRAVITY = 1.0f;
    private float timeBeforeChangeGravity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gravity = GetComponent<ConstantForce2D>();
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

        timeBeforeChangeGravity -= Time.fixedDeltaTime;
        timeBeforeChangeGravity = Mathf.Max(0.0f, timeBeforeChangeGravity);

        if(Input.GetKey(changeGravity) && timeBeforeChangeGravity == 0.0f)
        {
            gravity.force *= -1.0f;
            timeBeforeChangeGravity = TIMEBEFORECHANGEGRAVITY;
        }
    }
}
