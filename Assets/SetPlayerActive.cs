using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerActive : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    public Vector2 teleportDestination { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActivatePlayer()
    {
        player.GetComponent<SpriteRenderer>().enabled = true;
        SetPlayerTransformPosition();
    }
    private void SetPlayerTransformPosition()
    {
        teleportDestination = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
        player.gameObject.transform.position = teleportDestination;
        Debug.Log("Trying to call Player StartSection");
        player.GetComponent<Player>().StartSection();
    }
}
