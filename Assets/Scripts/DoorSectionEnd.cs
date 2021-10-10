using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSectionEnd : MonoBehaviour
{

    [SerializeField]
    private GameObject camera;
    [SerializeField]
    private GameObject player1NextPos;
    [SerializeField]
    private GameObject player2NextPos;

    private int nbPlayers = 0;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Player"))
        {
            collision.gameObject.SendMessage("EndSection");
            nbPlayers++;
            if (nbPlayers >= 2)
            {
                camera.GetComponent<CameraController>().NextPos();
                player1NextPos.GetComponent<SetPlayerActive>().ActivatePlayer();
                player2NextPos.GetComponent<SetPlayerActive>().ActivatePlayer();
            }
        }
    }
}
