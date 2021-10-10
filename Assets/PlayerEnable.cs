using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnable : MonoBehaviour
{
    [SerializeField]
    private GameObject player1;
    [SerializeField]
    private GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        player1.GetComponent<Player>().enabled = true;
        player2.GetComponent<Player>().enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
